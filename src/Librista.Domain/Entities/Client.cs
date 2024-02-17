using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class Client : IAuditable
{
    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    [MaxLength(30)]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Precision(18, 2)]
    public decimal TotalFines { get; set; } = 0;
    public long AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public List<BorrowingRecord> BorrowingRecords { get; set; } = [];
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}