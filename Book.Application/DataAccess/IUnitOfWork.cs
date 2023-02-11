using Book.Infrastructure.Repository;
using Shared.BaseModels.BaseEntities;

namespace Book.Application.DataContext;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}