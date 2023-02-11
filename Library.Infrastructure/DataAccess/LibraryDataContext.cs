using Library.Application.DataAccess;
using Library.Application.Repository;
using Library.Domain.Entities;
using Library.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Library.Infrastructure.DataAccess;

public class LibraryDataContext: DbContext, IUnitOfWork 
{
    private DbSet<RentalHistory> _RentalsHistory { get; set; } 
    private DbSet<Rental> _Rentals { get; set; } 
    private DbSet<User> _Users { get; set; } 
    private DbSet<Admin> _Admins { get; set; } 
    private DbSet<Book> _Books { get; set; } 
    private DbSet<Domain.Entities.Library> _Libraries { get; set; } 

    public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Library>().HasMany(c => c.Rentals).WithOne(c => c.Library).HasForeignKey(c => c.LibraryId);
        modelBuilder.Entity<Domain.Entities.Library>().OwnsOne(c => c.Address);
        
        modelBuilder.Entity<Rental>().HasOne(c => c.Book)
            .WithOne(c => c.Rental)
            .HasForeignKey<Book>(c => c.RentalId);
        
        modelBuilder.Entity<Book>().HasOne(c => c.Rental)
            .WithOne(c => c.Book)
            .HasForeignKey<Rental>(c => c.BookId);

    }   

    public IRentalRepository Rentals => new RentalRepository(_Rentals);
    public IRentalHistoryRepository RentalsHistory => new RentalHistoryRepository(_RentalsHistory);
    public IUserRepository Users => new UserRepository(_Users);
    public IBaseRepository<Admin> Admins => new BaseRepository<Admin>(_Admins);
    public IBaseRepository<Book> Books => new BaseRepository<Book>(_Books);
    public IBaseRepository<Domain.Entities.Library> Libraries => new BaseRepository<Domain.Entities.Library>(_Libraries);
}

//create migration use this
//dotnet ef migrations add 'NAME' --project ..\Identity.Infrastructure\Identity.Infrastructure.csproj
//dotnet ef database update -- --environment Development
//in API project