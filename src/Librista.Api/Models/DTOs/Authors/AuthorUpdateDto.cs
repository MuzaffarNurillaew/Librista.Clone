namespace Librista.Api.Models.DTOs.Authors;

public class AuthorUpdateDto
{
    public required string Name { get; set; }
    public string? Biography { get; set; }
}