using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IAddressService
{
    Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default);
    Task<Address> GetAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Address>> GetAllAsync(AddressFilter filter, CancellationToken cancellationToken = default);
    Task<Address> UpdateAsync(long id, Address address, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
    
}