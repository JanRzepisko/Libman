using Identity.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Identity.Application.DataAccess;

public interface IUnitOfWork
{
    IBaseRepository<User> Users { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}