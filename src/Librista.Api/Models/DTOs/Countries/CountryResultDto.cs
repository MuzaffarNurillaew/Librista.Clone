using Librista.Api.Models.DTOs.Cities;

namespace Librista.Api.Models.DTOs.Countries;

public class CountryResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public List<CityResultDto>? Cities { get; set; }
}