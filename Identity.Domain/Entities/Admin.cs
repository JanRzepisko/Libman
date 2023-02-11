using Identity.Domain.Entities.Abstract;
using Shared.BaseModels.BaseEntities;

namespace Identity.Domain.Entities;

public class Admin : UserModel
{
    public string Password { get; set; }
}