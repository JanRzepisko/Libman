using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class Rentals : Entity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateOnly RentalDate { get; set; }
}