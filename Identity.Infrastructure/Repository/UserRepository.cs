using Identity.Application.Repository;
using Identity.Domain.Entities;
using Identity.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace Identity.Infrasturcture.Repository;

public class UserRepository<TEntity> : BaseRepository<TEntity>, IUserRepository<TEntity> where TEntity : UserModel, new()
{
    public UserRepository(DbSet<TEntity>? entities) : base(entities)
    {
    }


    public Task<bool> IsEmailExist(string email, CancellationToken cancellationToken = default)
    {
        return _entities.AnyAsync(c => c.Email == email, cancellationToken);
    }

    public Task<TEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _entities.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }
}