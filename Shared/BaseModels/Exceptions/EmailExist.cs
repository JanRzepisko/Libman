namespace Shared.BaseModels.Exceptions;

public class EmailExist : BaseException
{
    public override int StatusCodeToRise => 400;
    public EmailExist() : base("Email already exist")
    {
    }

    public EmailExist(Dictionary<string, string[]> errors) : base(errors)
    {
    }
}