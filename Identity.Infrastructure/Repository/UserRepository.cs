using Identity.Application.Repository;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Identity.Infrasturcture.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbSet<User>? entities) : base(entities)
    {
    }


    public Task<bool> IsEmailExist(string email, CancellationToken cancellationToken = default)
    {
        return _entities.AnyAsync(c => c.Email == email, cancellationToken);
    }

    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _entities.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }
}