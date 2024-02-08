using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class BorrowingRecord : Auditable
{
    public long BookId { get; set; }
    public Book Book { get; set; }
    public long ClientId { get; set; }
    public Client Client { get; set; }
    public DateTimeOffset BorrowingDate { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public DateTimeOffset ReturningDate { get; set; }
    public decimal? TotalFines { get; set; }
}