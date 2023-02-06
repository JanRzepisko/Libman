using FluentValidation;
using Identity.Application.DataAccess;
using MediatR;
using Shared.BaseModels.Exceptions;

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
            if (await _unitOfWork.Users.IsEmailExist(request.Email, cancellationToken))
            {
                throw new EmailExist();
            }
            
            await _unitOfWork.Users.AddAsync(new Domain.Entities.User()
            {
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
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
                RuleFor(x => x.Surname).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(c => c.Password).Equal(c => c.ConfirmPassword);
            }
        }
    }
}
