using FluentValidation;
using Identity.Application.DataAccess;
using MediatR;

namespace Identity.Application.Actions.Command.User;

public static class RegisterUser
{
    public sealed record Command(string Name, string Surname, string Email, string Password, string ConfirmPassword) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Users.AddAsync(new Domain.Entities.User()
            {
                Password = request.Password,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            }, cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Password).Equal(c => c.ConfirmPassword);
            }
        }
    }
}
