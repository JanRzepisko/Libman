namespace Shared.Messages;

public class UserCreatedEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid LibraryId { get; set; }
}