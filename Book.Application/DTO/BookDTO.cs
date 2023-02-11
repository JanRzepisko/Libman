namespace Book.Application.DTO;

public class BookDTO
{
    public string Title { get; set; }
    public AuthorDTO Author { get; set; }
    public int ReleaseYear { get; set; }
    public bool IsAvailable { get; set; }
    
    public static BookDTO FromEntity(Domain.Entities.Book book)
    {
        return new BookDTO
        {
            Title = book.Title,
            Author = AuthorDTO.FromEntity(book.Author),
            ReleaseYear = book.ReleaseYear,
            IsAvailable = book.IsAvailable
        };
    }
}