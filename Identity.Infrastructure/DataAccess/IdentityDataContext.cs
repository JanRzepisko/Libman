using Identity.Application.DataAccess;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Identity.Infrastructure.DataAccess;

public class IdentityDataContext: DbContext, IUnitOfWork 
{
    
    private DbSet<User> _Users { get; set; }
    public IBaseRepository<User> Users => new BaseRepository<User>(_Users);

    
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}

//create migration use this
//dotnet ef migrations add init3 --project ..\Identity.Infrastructure\Identity.Infrastructure.csproj
//dotnet ef database update -- --environment Development
//in API project