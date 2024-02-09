using Newtonsoft.Json;

namespace Librista.Service.Models.IntegrationModels;

public class CountryApiResponse
{
    [JsonProperty("data")] public List<CountryApiModel> Data { get; set; } = [];
}