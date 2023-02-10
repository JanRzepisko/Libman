using Book.Infrastructure.Repository;
using Shared.BaseModels.BaseEntities;

namespace Book.Application.DataContext;

public interface IUnitOfWork
{
    IBaseRepository<Domain.Entities.Book> Books { get; }
    IAuthorRepository Authors { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}