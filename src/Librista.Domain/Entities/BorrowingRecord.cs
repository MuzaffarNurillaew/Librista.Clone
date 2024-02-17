using System.ComponentModel.DataAnnotations;
using Librista.Domain.Commons;
using Microsoft.AspNetCore.Identity;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="IAuditable"/>
public class BorrowingRecord : IAuditable
{
    public long BookId { get; set; }
    public Book Book { get; set; } = null!;
    
    public long ClientId { get; set; }
    public Client Client { get; set; } = null!;
    
    public DateTimeOffset BorrowingDate { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public DateTimeOffset ReturningDate { get; set; }
    
    public decimal? TotalFines { get; set; }
    public bool? IsPaid { get; set; }
    public bool IsReturned { get; set; }
    [Key]
    public long Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateService.Now();
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}

public class User : IdentityUser<long>
{
    
}