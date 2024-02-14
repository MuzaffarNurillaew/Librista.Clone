using Librista.Service.Interfaces.Filters;

namespace Librista.Service.Filters;

public class BookFilter : ISearchable, IPagable, IAuditableFilter
{
    public string? Search { get; set; }
    public PaginationParameters PaginationParameters { get; set; } = new();
    public DateTimeOffset? MinimumCreationDate { get; set; }
    public DateTimeOffset? MaximumCreationDate { get; set; }
    public DateTimeOffset? MinimumPublicationDate { get; set; }
    public DateTimeOffset? MaximumPublicationDate { get; set; }
    public long? GenreId { get; set; }
    public long? PublisherId { get; set; }
}