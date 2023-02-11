using Library.Domain.Entities;

namespace Library.Application.DTO;

public class RentalHistoryDTO
{
    public Guid Id { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public BookDTO Book { get; set; }
    public UserDTO User { get; set; }

    
    public static RentalHistoryDTO FromEntity(RentalHistory rentalHistory)
    {
        return new RentalHistoryDTO
        {
            Id = rentalHistory.Id,
            RentalDate = rentalHistory.RentalDate,
            ReturnDate = rentalHistory.ReturnDate,
            Book = BookDTO.FromEntity(rentalHistory.Book),
            User = UserDTO.FromEntity(rentalHistory.User)
        };
    }
}