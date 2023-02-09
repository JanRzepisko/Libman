using Shared.BaseModels.BaseEntities;

namespace Library.Domain.Entities;

public class Admin : Entity
{
    public Guid? LibraryId { get; set; }
    public Library? Library { get; set; }
    public string FullName { get; set; }
}