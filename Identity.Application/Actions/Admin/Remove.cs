using FluentValidation;
using Identity.Application.DataAccess;
using MediatR;
using Shared.BaseModels.Exceptions;
using Shared.Service.Interfaces;

namespace Identity.Application.Actions.Command.Admin;

public static class RemoveAdmin
{
    public sealed record Command() : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id, cancellationToken);
            if (user is null)
            {
                throw new EntityNotFound<Domain.Entities.User>();
            }
            
            _unitOfWork.Admins.Remove(user);
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
