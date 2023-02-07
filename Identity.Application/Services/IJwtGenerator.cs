using Identity.Domain.Entities;
using Identity.Domain.Entities.Abstract;
using Identity.Domain.Results;

namespace Identity.Application.Services;

public interface IJwtGenerator
{
    public Task<JwtResult> GenerateJwt(UserModel user, CancellationToken cancellationToken);
}