namespace Shared.Messages;

public class AdminCreatedEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? LibraryId { get; set; }
}