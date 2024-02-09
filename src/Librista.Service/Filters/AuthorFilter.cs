using Librista.Service.Interfaces.Filters;

namespace Librista.Service.Filters;

public class AuthorFilter : ISearchable, IPagable, IAuditableFilter
{
    public string? Search { get; set; }
    public PaginationParameters? PaginationParameters { get; set; }
    public DateTimeOffset? MinimumCreationDate { get; set; }
    public DateTimeOffset? MaximumCreationDate { get; set; }
}