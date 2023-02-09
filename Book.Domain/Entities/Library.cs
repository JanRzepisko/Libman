using System.Collections.ObjectModel;
using Shared.BaseModels.BaseEntities;

namespace Book.Domain.Entities;

public class Library : Entity
{
    public Collection<Book> Books { get; set; }
}