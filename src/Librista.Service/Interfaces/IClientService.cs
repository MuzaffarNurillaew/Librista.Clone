using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IClientService
{
    Task<Client> CreateAsync(Client client,
        CancellationToken cancellationToken = default);
    Task<Client> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<List<Client>> GetAllAsync(ClientFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<Client> UpdateAsync(long id,
        Client client,
        bool throwException = true,
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}