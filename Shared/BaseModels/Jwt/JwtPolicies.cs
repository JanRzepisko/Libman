using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Extensions;
using Shared.PublicEnums;

namespace Shared.BaseModels.Jwt;

public static class JwtPolicies
{
    public static readonly string Admin = JwtRoles.Admin.GetDisplayName();
    public static readonly string User = JwtRoles.User.GetDisplayName();

    public static AuthorizationPolicy AdminPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
    }

    public static AuthorizationPolicy UserPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
    }
}