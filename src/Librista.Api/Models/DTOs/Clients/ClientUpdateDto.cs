namespace Librista.Api.Models.DTOs.Clients;

public class ClientUpdateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public long AddressId { get; set; }
}