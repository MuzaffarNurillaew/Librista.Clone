using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.EntityFrameworkCore;

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
    
    [Precision(18, 2)]
    public decimal TotalFines { get; set; } = 0;
    public long AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<BorrowingRecord> BorrowingRecords { get; set; } = [];
}