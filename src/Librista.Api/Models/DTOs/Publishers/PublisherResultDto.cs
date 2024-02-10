using Librista.Api.Models.DTOs.Addresses;
using Librista.Api.Models.DTOs.Books;

namespace Librista.Api.Models.DTOs.Publishers;

public class PublisherResultDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    
    public long AddressId { get; set; }
    public AddressResultDto Address { get; set; } = null!;
    
    public List<BookResultDto> Books { get; set; } = [];    
}