using Shared.BaseModels.BaseEntities;

namespace Book.Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public Guid LibraryId { get; set; }
    public Library Library { get; set; }
    public int ReleaseYear { get; set; }
    public bool IsAvailable { get; set; }
}