using Library.Domain.Entities;

namespace Library.Application.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public List<RentalDTO> Rentals { get; set; }
    
    public static UserDTO FromEntity(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Fullname = user.FullName,
            Rentals = (user.ActiveRentals ?? new List<Rental>()).Select(RentalDTO.FromEntity).ToList()
        };
    }
}