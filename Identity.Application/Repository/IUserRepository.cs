using Identity.Domain.Entities;
using Identity.Domain.Entities.Abstract;
using Shared.BaseModels.BaseEntities;

namespace Identity.Application.Repository;

public interface IUserRepository<TEntity> : IBaseRepository<TEntity> where TEntity : UserModel
{
    Task<bool> IsEmailExist(string email, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}