using FluentValidation;
using Identity.Application.DataAccess;
using MediatR;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;
using Shared.Service.Interfaces;

namespace Identity.Application.Actions.Command.User;

public static class CreateUser
{
    public sealed record Command(string Firstname, string Surname, string Email) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IEventBus eventBus, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Users.IsEmailExist(request.Email, cancellationToken))
            {
                throw new EmailExist();
            }

            var creator = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id, cancellationToken);
            if (creator.LibraryId == null)
            {
                throw new InvalidRequestException("Creator must have library");
            }
            
            Guid id = Guid.NewGuid();
            await _unitOfWork.Users.AddAsync(new Domain.Entities.User()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Surname = request.Surname,
                Id = id,
                LibraryId = creator.LibraryId
            }, cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            await _eventBus.PublishAsync(new UserCreatedEvent()
            {
                Id = id,
                Name = request.Firstname + " " + request.Surname,
                LibraryId = creator.LibraryId
            }, cancellationToken);
            
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Surname).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
            }
        }
    }
}
