using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class Rental : Entity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid LibraryId { get; set; }
    public Library Library { get; set; }
    public DateOnly RentalDate { get; set; }
    public DateOnly ReturnDate { get; set; }
}