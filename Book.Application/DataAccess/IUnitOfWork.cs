using Shared.BaseModels.BaseEntities;

namespace Book.Application.DataContext;

public interface IUnitOfWork
{
    IBaseRepository<Domain.Entities.Book> Books { get; }
    IBaseRepository<Domain.Entities.Author> Authors { get; }
    IBaseRepository<Domain.Entities.Library> Libraries { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}