using Identity.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace Identity.Application.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsEmailExist(string email, CancellationToken cancellationToken = default);
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}