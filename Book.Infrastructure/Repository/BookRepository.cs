using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.Repository;

public class BookRepository : BaseRepository<Domain.Entities.Book>, IBookRepository
{
    public BookRepository(DbSet<Domain.Entities.Book>? entities) : base(entities)
    {
    }
    
    public Task<List<Domain.Entities.Book>> Search(string requestQuery, int page, Guid LibraryId, CancellationToken cancellationToken)
    {
        return _entities.Where(c => c.Title.Contains(requestQuery) && c.LibraryId == LibraryId)
                        .Include(c => c.Author)
                        .Skip(page * 5)
                        .Take((page+1) *5 )
                        .ToListAsync(cancellationToken);
    }
}