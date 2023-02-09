using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class RentalHistory : Entity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid LibraryId { get; set; }
    public Library Library { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
}