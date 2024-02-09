using Librista.Api.Models.DTOs.Countries;
using Librista.Domain.Entities;

namespace Librista.Api.Models.DTOs.Cities;

public class CityResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public CountryResultDto Country { get; set; } = null!;
}