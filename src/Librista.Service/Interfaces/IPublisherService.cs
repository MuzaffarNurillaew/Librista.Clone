using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IPublisherService
{
    Task<Publisher> CreateAsync(Publisher publisher,
        CancellationToken cancellationToken = default);
    Task<Publisher> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<List<Publisher>> GetAllAsync(PublisherFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<Publisher> UpdateAsync(long id,
        Publisher publisher,
        bool throwException = true,
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}