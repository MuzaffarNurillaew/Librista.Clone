namespace Librista.Api.Models.DTOs.Addresses;

public class AddressUpdateDto
{
    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public long CityId { get; set; }
    public decimal? Longitude { get; set; }
    public decimal? Latitude { get; set; }
}