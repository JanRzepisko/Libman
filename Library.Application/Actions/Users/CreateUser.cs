using FluentValidation;
using Library.Application.DataAccess;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Actions.Users;

public static class CreateUser
{
    public sealed record Command(Guid Id, string FullName, Guid? LibraryId) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Users.AddAsync(new User()
            {
                Id = request.Id,
                LibraryId = request.LibraryId,
                FullName = request.FullName
            }, cancellationToken);
            
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