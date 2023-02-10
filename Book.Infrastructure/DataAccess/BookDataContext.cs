using Book.Application.DataContext;
using Book.Domain.Entities;
using Book.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.DataContext;

public class BookDataContext : DbContext, IUnitOfWork
{
    private DbSet<Domain.Entities.Book> _Books { get; set; }
    private DbSet<Author> _Authors { get; set; }

    public IBaseRepository<Domain.Entities.Book> Books => new BaseRepository<Domain.Entities.Book>(_Books);
    public IAuthorRepository Authors => new AuthorRepository(_Authors);

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