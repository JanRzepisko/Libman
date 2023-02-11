using Library.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Library.Application.Repository;

public interface IRentalRepository : IBaseRepository<Rental>
{
    Task<List<Rental>> GetByUser(Guid? userId, int page, CancellationToken cancellationToken);
}