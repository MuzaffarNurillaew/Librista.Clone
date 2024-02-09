using Newtonsoft.Json;

namespace Librista.Service.Models.IntegrationModels;

public class CountryApiModel
{
    [JsonProperty("country")]
    public required string Country { get; set; }
    
    [JsonProperty("cities")]
    public List<string> Cities { get; set; } = [];
}