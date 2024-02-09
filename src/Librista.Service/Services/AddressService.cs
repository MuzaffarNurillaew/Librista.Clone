using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Services;

public class AddressService(IRepository repository, AddressValidator validator) : IAddressService
{
    public async Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default)
    {
        await validator.ValidateOrPanicAsync(address);
        var createdEntity = await repository.InsertAsync(address, cancellationToken: cancellationToken);
        return createdEntity;
    }

    public async Task<Address> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.SelectAsync<Address>(address => address.Id == id,
            shouldThrowException: true, cancellationToken: cancellationToken);

        return entity;
    }

    public async Task<List<Address>> GetAllAsync(AddressFilter filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Address> UpdateAsync(long id, Address address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}