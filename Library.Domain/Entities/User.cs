using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class User : Entity
{
    public string FullName { get; set; }
    public Guid? LibraryId { get; set; }
    public Library? Library { get; set; }
    public ICollection<Rental> ActiveRelant { get; set; }
    public ICollection<RentalHistory> RelantsHistory { get; set; }
}