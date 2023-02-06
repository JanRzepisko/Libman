using Identity.Domain.Entities;
using Identity.Domain.Results;

namespace Identity.Application.Services;

public interface IJwtGenerator
{
    public Task<JwtResult> GenerateJwt(User user);
}