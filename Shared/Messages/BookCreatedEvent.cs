namespace Shared.Messages;

public class BookCreatedEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid LibraryId { get; set; }
}