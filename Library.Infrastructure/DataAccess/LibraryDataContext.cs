using Library.Application.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.DataAccess;

public class LibraryDataContext: DbContext, IUnitOfWork 
{

    
    public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}

//create migration use this
//dotnet ef migrations add 'NAME' --project ..\Identity.Infrastructure\Identity.Infrastructure.csproj
//dotnet ef database update -- --environment Development
//in API project