using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Publisher : Auditable
{
    [MaxLength(25)]
    public required string Name { get; set; }
    
    public long AddressId { get; set; }
    public Address Address { get; set; } = null!;
    
    public List<Book> Books { get; set; } = [];
}