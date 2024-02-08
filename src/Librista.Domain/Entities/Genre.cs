using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Genre : Auditable
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}