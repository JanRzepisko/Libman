using System.Collections;
using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; }
    public Guid LibraryId { get; set; }
    public Library Library { get; set; }
    public Guid? RentalId { get; set; } 
    public Rental? Rental { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<RentalHistory>? RentalsHistory { get; set; }
}