using FluentValidation;
using Identity.Application.DataAccess;
using Identity.Application.Services;
using Identity.Domain.Results;
using MediatR;
using Shared.BaseModels.Exceptions;
using Shared.BaseModels.Jwt;

namespace Identity.Application.Actions.Query.Admin;

public static class LoginAdmin
{
    public sealed record Command(string Email, string Password) : IRequest<JwtResult>;

    public class Handler : IRequestHandler<Command, JwtResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtGenerator _jwt;

        public Handler(IUnitOfWork unitOfWork, IJwtGenerator jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        public async Task<JwtResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Admins.GetByEmailAsync(request.Email, cancellationToken);
            if (user is null)
            {
                throw new EntityNotFound<Domain.Entities.User>();
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new BadPassword();
            }
            
            return await _jwt.GenerateJwt(user, JwtPolicies.Admin, cancellationToken);
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                
            }
        }
    }
}
