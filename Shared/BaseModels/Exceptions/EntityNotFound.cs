namespace Shared.BaseModels.Exceptions;

public class EntityNotFound<T> : BaseException
{
    public EntityNotFound() : base($"{typeof(T).Name} not found")
    {
    }
    
    public override int StatusCodeToRise => 404;
}