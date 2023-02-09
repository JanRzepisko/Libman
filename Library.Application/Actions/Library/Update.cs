using FluentValidation;
using Library.Application.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.Service.Interfaces;

namespace Library.Application.Actions.Library;

public static class UpdateLibrary
{
    public sealed record Command(string? Name, string? Street, string? City, string? Country) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id, cancellationToken);
            var library = await _unitOfWork.Libraries.GetByIdAsync(admin.LibraryId, cancellationToken);
            
            library.Name = request.Name ?? library.Name;
            library.Address.Street = request.Street ?? library.Address.Street;
            library.Address.City = request.City ?? library.Address.City;
            library.Address.Country = request.Country ?? library.Address.Country;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}