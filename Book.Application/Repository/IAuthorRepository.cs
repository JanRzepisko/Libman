using Book.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.Repository;

public interface IAuthorRepository : IBaseRepository<Author>
{
    public Task<bool>ExistNameAsync(string Firstname, string Surname, CancellationToken cancellationToken);
    Task<List<Author>>Search(string requestQuery, int page, CancellationToken cancellationToken);
}