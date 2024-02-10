using System.ComponentModel.DataAnnotations;

namespace Librista.Api.Models.DTOs.Clients;

public class ClientCreationDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public long AddressId { get; set; }
}