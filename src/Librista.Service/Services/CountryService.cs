using AutoMapper;
using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Domain.Exceptions;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Models.IntegrationModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Librista.Service.Services;

public class CountryService(IRepository repository, IMapper mapper) : ICountryService
{
    private const string CountriesUrl = "https://countriesnow.space/api/v0.1/countries/";
    public async Task CreateAllAsync(CancellationToken cancellationToken = default)
    {
        if (await repository.SelectAll<Country>(country => true).AnyAsync(cancellationToken: cancellationToken))
        {
            throw new CustomException(400, "Countries and cities are already created.");
        }
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(CountriesUrl, cancellationToken);
        var countryApiResponse =
            JsonConvert.DeserializeObject<CountryApiResponse>(await response.Content.ReadAsStringAsync(cancellationToken));
        var countries = mapper.Map<List<Country>>(countryApiResponse?.Data);

        await repository.InsertManyAsync(countries, cancellationToken: cancellationToken);
    }

    public async Task<List<Country>> GetAllAsync(CountryFilter filter, CancellationToken cancellationToken = default)
    {
        var countriesQuery = repository.SelectAll<Country>(country => true);

        #region Filtering

        if (filter.Search is not null)
        {
            countriesQuery = countriesQuery
                .Where(country =>
                    country.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase));
        }

        countriesQuery = countriesQuery.FilterAuditable(filter);
        countriesQuery = countriesQuery.FilterPagable(filter);

        #endregion

        return await countriesQuery.ToListAsync(cancellationToken);
    }
}