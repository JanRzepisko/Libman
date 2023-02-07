namespace Shared.BaseModels.Exceptions;

public class BadPassword : BaseException
{
    public override int StatusCodeToRise => 400;
    public BadPassword() : base("Bad Password")
    {
    }

    public BadPassword(Dictionary<string, string[]> errors) : base(errors)
    {
    }
}