using Shared.BaseModels.ApiControllerModels;

namespace Identity.Domain.Results;

public class JwtResult : BaseResult
{
    public string Token { get; }

    public JwtResult(string token)
    {
        Token = token;
    }
}