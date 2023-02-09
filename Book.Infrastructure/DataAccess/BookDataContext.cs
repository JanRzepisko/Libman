using Book.Application.DataContext;
using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.DataContext;

public class BookDataContext : DbContext, IUnitOfWork
{
    DbSet<Domain.Entities.Book> _Books { get; }
    DbSet<Domain.Entities.Library> _Libraries { get; }
    DbSet<Domain.Entities.Author> _Authors { get; }

    public IBaseRepository<Domain.Entities.Book> Books => new BaseRepository<Domain.Entities.Book>(_Books);
    public IBaseRepository<Author> Authors => new BaseRepository<Author>(_Authors);
    public IBaseRepository<Domain.Entities.Library> Libraries => new BaseRepository<Domain.Entities.Library>(_Libraries);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    public BookDataContext(DbContextOptions<BookDataContext> options) : base(options)
    {
        
    }
}

//create migration use this
//dotnet ef migrations add 'NAME' --project ..\Book.Infrastructure\Book.Infrastructure.csproj
//dotnet ef database update -- --environment Development
//in API project