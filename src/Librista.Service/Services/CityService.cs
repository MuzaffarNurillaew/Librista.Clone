using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class CityService(IRepository repository) : ICityService
{
    public async Task<City> GetAsync(long id, bool throwException = true, bool loadRelations = false, CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(City.Country) } : null!;
        var city = await repository.SelectAsync<City>(city => city.Id == id,
            shouldThrowException: throwException,
            includes: includes,
            cancellationToken: cancellationToken);

        return city;
    }

    public async Task<List<City>> GetAllAsync(CityFilter filter, bool loadRelations = false, CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(City.Country) } : null!;
        var citiesQuery = repository
            .SelectAll<City>(city => true, includes: includes);

        #region Filtering

        if (filter.Search is not null)
        {
            citiesQuery = citiesQuery.Where(city =>
                city.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) ||
                city.Country.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase));
        }

        citiesQuery.FilterPagable(filter).FilterAuditable(filter);
        #endregion

        return await citiesQuery.ToListAsync(cancellationToken: cancellationToken);
    }
}