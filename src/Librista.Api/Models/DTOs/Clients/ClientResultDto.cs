using Librista.Api.Models.DTOs.Addresses;
using Librista.Api.Models.DTOs.BorrowingRecords;

namespace Librista.Api.Models.DTOs.Clients;

public class ClientResultDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public decimal TotalFines { get; set; } = 0;
    public long AddressId { get; set; }
    public AddressResultDto Address { get; set; } = null!;
    public List<BorrowingRecordResultDto> BorrowingRecords { get; set; } = [];
}