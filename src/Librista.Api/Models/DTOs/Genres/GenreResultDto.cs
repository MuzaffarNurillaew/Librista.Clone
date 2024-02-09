using Librista.Api.Models.DTOs.Books;

namespace Librista.Api.Models.DTOs.Genres;

public class GenreResultDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public List<BookResultDto>? Books { get; set; }
}