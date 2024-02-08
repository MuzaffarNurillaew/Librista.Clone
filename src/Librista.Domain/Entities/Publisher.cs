using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Publisher : Auditable
{
    public string Name { get; set; }
    public long AddressId { get; set; }
    public Address Address { get; set; }
    public List<Book> Books { get; set; }
}