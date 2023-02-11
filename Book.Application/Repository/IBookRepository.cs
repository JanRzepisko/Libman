using Book.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.Repository;

public interface IBookRepository : IBaseRepository<Domain.Entities.Book>
{
    Task<List<Domain.Entities.Book>> Search(string requestQuery, int page, Guid LibraryId, CancellationToken cancellationToken);
}