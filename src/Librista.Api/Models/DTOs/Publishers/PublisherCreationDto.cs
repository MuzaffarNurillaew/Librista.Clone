namespace Librista.Api.Models.DTOs.Publishers;

public class PublisherCreationDto
{
    public required string Name { get; set; }
    public long AddressId { get; set; }
}