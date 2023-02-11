namespace Shared.Messages;

public class ChangedBookStatusEvent
{
    public Guid BookId { get; set; }
    public bool IsAvailable { get; set; }
}