using Librista.Service.Interfaces.Filters;

namespace Librista.Service.Filters;

public class AddressFilter : ISearchable
{
    public string? Search { get; set; }
    public string? StreetNamePattern { get; set; }
    public string? BuildingNumberPattern { get; set; }
    public decimal? MinimumLongitude { get; set; }
    public decimal? MaximumLongitude { get; set; }
    public decimal? MinimumLatitude { get; set; }
    public decimal? MaximumLatitude { get; set; }
}