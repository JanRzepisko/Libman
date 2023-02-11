namespace Shared.Messages;

public class BookRemovedEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}