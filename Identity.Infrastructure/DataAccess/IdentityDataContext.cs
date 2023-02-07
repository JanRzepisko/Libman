using Identity.Application.DataAccess;
using Identity.Application.Repository;
using Identity.Domain.Entities;
using Identity.Infrasturcture.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Identity.Infrastructure.DataAccess;

public class IdentityDataContext: DbContext, IUnitOfWork 
{
    
    private DbSet<User> _Users { get; set; }
    private DbSet<User> _Admin { get; set; }
    public IUserRepository Users => new UserRepository(_Users);
    public IUserRepository Admins => new UserRepository(_Admin);

    
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