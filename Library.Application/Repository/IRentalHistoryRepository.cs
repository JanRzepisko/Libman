using Library.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Library.Application.Repository;

public interface IRentalHistoryRepository : IBaseRepository<RentalHistory>
{
    Task<List<RentalHistory>> GetByLibrary(Guid? libraryId, int page, CancellationToken cancellationToken);
}