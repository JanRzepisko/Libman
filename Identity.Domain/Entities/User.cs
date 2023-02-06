using Shared.BaseModels.BaseEntities;

namespace Identity.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}