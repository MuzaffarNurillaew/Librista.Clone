using Librista.Domain.Commons;

namespace Librista.Domain.Entities;

/// <inheritdoc cref="Auditable"/>
public class Address : Auditable
{
    public string GeneratedName { get; set; }
    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
    public decimal? Longitude { get; set; }
    public decimal? Latitude { get; set; }
}