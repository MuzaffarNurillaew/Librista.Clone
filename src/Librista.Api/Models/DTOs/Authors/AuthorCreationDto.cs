namespace Librista.Api.Models.DTOs.Authors;

public class AuthorCreationDto
{
    public required string Name { get; set; }
    public string? Biography { get; set; }
}