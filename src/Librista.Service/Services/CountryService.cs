using AutoMapper;
using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Domain.Exceptions;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Models.IntegrationModels;
using Microsoft.AspNetCore.Http;
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
            throw new CustomException(StatusCodes.Status409Conflict, "Countries and cities are already created.");
        }
        
        var client = new HttpClient();
        var response = await client.GetAsync(CountriesUrl, cancellationToken);
        var countryApiResponse =
            JsonConvert.DeserializeObject<CountryApiResponse>(await response.Content.ReadAsStringAsync(cancellationToken));
        var countries = mapper.Map<List<Country>>(countryApiResponse?.Data);

        await repository.InsertManyAsync(countries, cancellationToken: cancellationToken);
    }

    public async Task<Country> GetAsync(long id, bool throwException = true, bool loadRelations = false, CancellationToken cancellationToken = default)
    {
        string[] includes = loadRelations ? [$"{nameof(Country.Cities)}"] : null!;
        var country = await repository.SelectAsync<Country>(country => country.Id == id,
            includes: includes,
            cancellationToken: cancellationToken);
        return country;
    }

    public async Task<List<Country>> GetAllAsync(CountryFilter filter, bool loadRelations = false, CancellationToken cancellationToken = default)
    {
        string[] includes = loadRelations ? [$"{nameof(Country.Cities)}"] : null!;
        var countriesQuery = repository.SelectAll<Country>(country => true,
            includes: includes);

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