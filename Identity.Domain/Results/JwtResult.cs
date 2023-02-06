namespace Identity.Domain.Results;

public class JwtResult
{
    private string Token { get; }

    public JwtResult(string token)
    {
        Token = token;
    }
}