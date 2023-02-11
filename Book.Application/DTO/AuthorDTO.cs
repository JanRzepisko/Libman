using Book.Domain.Entities;

namespace Book.Application.DTO;

public class AuthorDTO
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    
    public static AuthorDTO FromEntity(Author author)
    {
        return new AuthorDTO
        {
            Id = author.Id,
            Firstname = author.Firstname,
            Surname = author.Surname
        };
    }
}