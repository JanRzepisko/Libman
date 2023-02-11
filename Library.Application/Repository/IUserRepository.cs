using Library.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Library.Application.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<List<User>> GetUsersByLibrary(Guid? adminLibraryId, int page, CancellationToken cancellationToken);
}