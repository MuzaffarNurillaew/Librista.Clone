using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Author : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    public List<Book> Books { get; set; }
}