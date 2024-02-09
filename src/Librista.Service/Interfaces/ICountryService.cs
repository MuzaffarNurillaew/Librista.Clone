using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface ICountryService
{
    Task CreateAllAsync(CancellationToken cancellationToken = default);
    Task<List<Country>> GetAllAsync(CountryFilter filter, CancellationToken cancellationToken);
}