using Library.Application.Repository;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Library.Infrastructure.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbSet<User>? entities) : base(entities)
    {
    }

    public Task<List<User>> GetUsersByLibrary(Guid? adminLibraryId, int page, CancellationToken cancellationToken)
    {
        return _entities.Where(c => c.LibraryId == adminLibraryId)
                        .Include(c => c.ActiveRentals)
                        .Include(c => c.RelantsHistory)
                        .Skip(page * 5)
                        .Take(5)
                        .ToListAsync(cancellationToken);
    }
}