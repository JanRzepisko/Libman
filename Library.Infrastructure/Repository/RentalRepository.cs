using Library.Application.Repository;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Library.Infrastructure.Repository;

public class RentalRepository : BaseRepository<Rental>, IRentalRepository
{
    public RentalRepository(DbSet<Rental>? entities) : base(entities)
    {
    }
    public Task<List<Rental>> GetByUser(Guid? userId, int page, CancellationToken cancellationToken)
    {
        return _entities.Where(c =>c.UserId == userId)
            .Include(c => c.Book)            
            .Skip(page * 5)
            .Take(5)
            .ToListAsync(cancellationToken);
    }
}