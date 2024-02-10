using Librista.Api.Models.DTOs.Authors;
using Librista.Api.Models.DTOs.BorrowingRecords;
using Librista.Api.Models.DTOs.Genres;
using Librista.Api.Models.DTOs.Publishers;

namespace Librista.Api.Models.DTOs.Books;

public class BookResultDto
{
    public required string Isbn { get; set; }
    public required string Title { get; set; }
    public string? Summary { get; set; }
    public string? Chapters { get; set; }
    public DateTimeOffset PublicationDate { get; set; }
    public int LeftCount { get; set; }
    public long GenreId { get; set; }
    public GenreResultDto? Genre { get; set; }
    public long PublisherId { get; set; }
    public PublisherResultDto? Publisher { get; set; }
    public List<AuthorResultDto>? Authors { get; set; }
    public List<BorrowingRecordResultDto>? BorrowingRecords { get; set; }
}