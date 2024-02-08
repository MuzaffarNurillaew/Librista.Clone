using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Client : Auditable
{
    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    [MaxLength(30)]
    public required string Email { get; set; }
    
    public long AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<BorrowingRecord> BorrowingRecords { get; set; } = [];
}