using Librista.Service.Interfaces.Filters;

namespace Librista.Service.Filters;

public class CountryFilter : ISearchable, IPagable, IAuditableFilter
{
    public string? Search { get; set; }
    public PaginationParameters? PaginationParameters { get; set; } = new();
    public DateTimeOffset? MinimumCreationDate { get; set; }
    public DateTimeOffset? MaximumCreationDate { get; set; }
}