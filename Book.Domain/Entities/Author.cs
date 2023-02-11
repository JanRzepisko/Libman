using Shared.BaseModels.BaseEntities;

namespace Book.Domain.Entities;

public class Author : Entity
{
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public ICollection<Book> Books { get; set; }
}