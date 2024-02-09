using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface ICityService
{
    Task<City> GetAsync(long id, bool throwException = true, bool loadRelations = false, CancellationToken cancellationToken = default);
    Task<List<City>> GetAllAsync(CityFilter filter, bool loadRelations = false, CancellationToken cancellationToken = default);
}