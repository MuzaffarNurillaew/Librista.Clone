using Librista.Api.Models.DTOs.Books;

namespace Librista.Api.Models.DTOs.Authors;

public class AuthorResultDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? Biography { get; set; }

    public List<BookResultDto> Books { get; set; } = [];
}