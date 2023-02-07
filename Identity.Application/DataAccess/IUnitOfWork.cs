using Identity.Application.Repository;
using Identity.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Identity.Application.DataAccess;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IUserRepository Admins { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}