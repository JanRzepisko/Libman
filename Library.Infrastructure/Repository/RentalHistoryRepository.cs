using Library.Application.Repository;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Library.Infrastructure.Repository;

public class RentalHistoryRepository : BaseRepository<RentalHistory>, IRentalHistoryRepository
{
    public RentalHistoryRepository(DbSet<RentalHistory>? entities) : base(entities)
    {
    }
    public Task<List<RentalHistory>> GetByLibrary(Guid? libraryId, int page, CancellationToken cancellationToken)
    {
        return _entities.Where(c =>c.LibraryId== libraryId)
            .Include(c => c.Book)            
            .Include(c => c.User)            
            .Skip(page * 5)
            .Take(5)
            .ToListAsync(cancellationToken);;
    }
}