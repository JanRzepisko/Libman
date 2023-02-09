namespace Shared.Messages;

public class ChangedBookStatus
{
    public Guid BookId { get; set; }
    public bool IsAvailable { get; set; }
}