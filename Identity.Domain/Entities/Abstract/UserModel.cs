using Shared.BaseModels.BaseEntities;

namespace Identity.Domain.Entities.Abstract;

public class UserModel : Entity
{
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
}
