using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Book.Infrastructure.Repository;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DbSet<Author>? entities) : base(entities)
    {
    }

    public Task<bool> ExistNameAsync(string Firstname, string Surname, CancellationToken cancellationToken)
    {
        return _entities.AnyAsync(c => c.Surname == Surname && c.Firstname == Firstname, cancellationToken);
    }

    public Task<List<Author>> Search(string requestQuery, int page, CancellationToken cancellationToken)
    {
        return _entities.Where(c => (c.Firstname + " " + c.Surname).Contains(requestQuery)).Skip(page * 5).Take((page+1) *5 ).ToListAsync(cancellationToken);
    }
}