using FluentValidation;
using Identity.Application.DataAccess;
using MediatR;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Identity.Application.Actions.Command.Admin;

public static class RegisterAdmin
{
    public sealed record Command(string Firstname, string Surname, string Email, string Password, string ConfirmPassword) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;

        public Handler(IUnitOfWork unitOfWork, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Admins.IsEmailExist(request.Email, cancellationToken))
            {
                throw new EmailExist();
            }
            Guid id = Guid.NewGuid();
            await _unitOfWork.Admins.AddAsync(new Domain.Entities.Admin()
            {
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                Firstname = request.Firstname,
                Surname = request.Surname,
                Id = id
            }, cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            await _eventBus.PublishAsync(new AdminCreatedEvent()
            {
                LibraryId = null,
                Id = id, 
                Name = request.Firstname + " " + request.Surname
            }, cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Surname).NotEmpty();
                RuleFor(x => x.Firstname).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(c => c.Password).Equal(c => c.ConfirmPassword);
            }
        }
    }
}
