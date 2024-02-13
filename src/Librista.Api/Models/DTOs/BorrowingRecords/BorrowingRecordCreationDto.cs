namespace Librista.Api.Models.DTOs.BorrowingRecords;

public class BorrowingRecordCreationDto
{
    public long BookId { get; set; }
    public long ClientId { get; set; }
    
    public DateTimeOffset BorrowingDate { get; set; }
    public DateTimeOffset Deadline { get; set; }
}