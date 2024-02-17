using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class Publisher : IAuditable
{
    [MaxLength(25)]
    public required string Name { get; set; }
    
    public long AddressId { get; set; }
    public Address Address { get; set; } = null!;
    
    public List<Book> Books { get; set; } = [];
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}