using FluentValidation;
using Library.Application.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.Service.Interfaces;

namespace Library.Application.Actions.Library;

public static class RemoveLibrary
{
    public sealed record Command() : IRequest<Unit>;

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
            _unitOfWork.Libraries.RemoveById((Guid)admin.LibraryId);
            
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