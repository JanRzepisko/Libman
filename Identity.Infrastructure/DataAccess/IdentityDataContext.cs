using Identity.Application.DataAccess;
using Identity.Application.Repository;
using Identity.Domain.Entities;
using Identity.Domain.Entities.Abstract;
using Identity.Infrasturcture.Migrations;
using Identity.Infrasturcture.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Identity.Infrastructure.DataAccess;

public class IdentityDataContext: DbContext, IUnitOfWork 
{
    
    private DbSet<User> _User { get; set; }
    private DbSet<Admin> _Admin { get; set; }
    
    public IUserRepository<User> Users => new UserRepository<User>(_User);
    public IUserRepository<Admin> Admins => new UserRepository<Admin>(_Admin);

    
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
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