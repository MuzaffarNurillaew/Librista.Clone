using Librista.Api.Models.DTOs.Authors;

namespace Librista.Api.Models.DTOs.Books;

public class BookCreationDto
{
    public required string Isbn { get; set; }
    public required string Title { get; set; }
    public string? Summary { get; set; }
    public string? Chapters { get; set; }
    
    public DateTimeOffset PublicationDate { get; set; }
    public int LeftCount { get; set; }
    
    public long GenreId { get; set; }
    public long PublisherId { get; set; }
    
    public required List<AuthorCreationDtoForBook> Authors { get; set; }
}