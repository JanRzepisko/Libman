namespace Shared.BaseModels.Exceptions;

public class EntityExist<T> : BaseException
{
    public EntityExist() : base($"{typeof(T).Name} not found")
    {
    }
    
    public override int StatusCodeToRise => 404;
}