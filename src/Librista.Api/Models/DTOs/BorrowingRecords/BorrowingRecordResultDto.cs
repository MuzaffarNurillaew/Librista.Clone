using Librista.Api.Models.DTOs.Books;
using Librista.Api.Models.DTOs.Clients;

namespace Librista.Api.Models.DTOs.BorrowingRecords;

public class BorrowingRecordResultDto
{
    public long Id { get; set; }
    public long BookId { get; set; }
    public BookResultDto Book { get; set; } = null!;
    
    public long ClientId { get; set; }
    public ClientResultDto Client { get; set; } = null!;
    
    public DateTimeOffset BorrowingDate { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public DateTimeOffset ReturningDate { get; set; }
    
    public decimal? TotalFines { get; set; }   
}