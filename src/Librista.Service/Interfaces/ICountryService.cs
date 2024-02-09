using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface ICountryService
{
    Task CreateAllAsync(CancellationToken cancellationToken = default);
    Task<Country> GetAsync(long id, bool throwException = true, bool loadRelations = false, CancellationToken cancellationToken = default);
    Task<List<Country>> GetAllAsync(CountryFilter filter, bool loadRelations = false, CancellationToken cancellationToken = default);
}