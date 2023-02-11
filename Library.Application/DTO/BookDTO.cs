namespace Library.Application.DTO;

public class BookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }
    
    public static BookDTO FromEntity(Domain.Entities.Book book)
    {
        return new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            IsAvailable = book.IsAvailable
        };
    }
}