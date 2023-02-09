using Library.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Library.Application.DataAccess;

public interface IUnitOfWork
{
    IBaseRepository<User> Users { get; }
    IBaseRepository<Rental> Rentals { get; }
    IBaseRepository<RentalHistory> RentalsHistory { get; }
    IBaseRepository<Admin> Admins { get; }
    IBaseRepository<Book> Books { get; }
    IBaseRepository<Domain.Entities.Library> Libraries { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}