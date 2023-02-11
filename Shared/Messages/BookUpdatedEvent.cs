namespace Shared.Messages;

public class BookUpdatedEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}