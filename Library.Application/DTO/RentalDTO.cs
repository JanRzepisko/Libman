using Library.Domain.Entities;

namespace Library.Application.DTO;

public class RentalDTO
{
    public Guid Id { get; set; }
    public DateTime RentalDate { get; set; }
    public BookDTO Book { get; set; }

    
    public static RentalDTO FromEntity(Rental rental)
    {
        return new RentalDTO
        {
            Id = rental.Id,
            Book = BookDTO.FromEntity(rental.Book),
            RentalDate = rental.RentalDate
        };
    }
}