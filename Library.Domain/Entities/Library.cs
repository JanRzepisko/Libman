using System.Collections;
using Library.Domain.ValueObjects;
using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class Library : Entity
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public ICollection<Book> Books { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Rental> Rentals { get; set; }
    public ICollection<RentalHistory> RentalsHistory { get; set; }
}