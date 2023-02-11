using Identity.Application.Repository;
using Identity.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Identity.Application.DataAccess;

public interface IUnitOfWork
{
    IUserRepository<User> Users { get; }
    IUserRepository<Admin> Admins { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}