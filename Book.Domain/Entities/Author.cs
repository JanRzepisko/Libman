using Shared.BaseModels.BaseEntities;

namespace Book.Domain.Entities;

public class Author : Entity
{
    public string Firsname { get; set; }
    public string Surname { get; set; }
    public int ReleaseYear { get; set; }
    public ICollection<Book> Books { get; set; }
}