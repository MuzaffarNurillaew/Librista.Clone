using System.Text;
using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Librista.Service.Services;

public class AddressService(IRepository repository, AddressValidator validator) : IAddressService
{
    public async Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default)
    {
        await validator.ValidateOrPanicAsync(address);
        // generating address string
        await GenerateAddressStringAsync(address);
        var createdEntity = await repository.InsertAsync(address, cancellationToken: cancellationToken);
        return createdEntity;
    }

    private async Task GenerateAddressStringAsync(Address address)
    {
        var city = await repository.SelectAsync<City>(city => city.Id == address.CityId,
            includes: [nameof(City.Country)]);
        var generetedNameSb = new StringBuilder();
        if (address.BuildingNumber is not null)
        {
            generetedNameSb.Append($"{address.BuildingNumber}, ");
        }
        if (address.Street is not null)
        {
            generetedNameSb.Append($"{address.Street}, ");
        }

        generetedNameSb.Append($"{city.Name}, ");
        generetedNameSb.Append(city.Country.Name);
        address.GeneratedName = generetedNameSb.ToString();
    }
    public async Task<Address> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await repository.SelectAsync<Address>(address => address.Id == id,
            shouldThrowException: true, cancellationToken: cancellationToken);

        return entity;
    }

    public async Task<List<Address>> GetAllAsync(AddressFilter filter, CancellationToken cancellationToken = default)
    {
        var addressesQuery = repository.SelectAll<Address>(address => true,
            includes: [$"{nameof(Address.City)}"]);

        #region Filtering
        if (filter.Search is not null)
        {
            filter.Search = filter.Search.ToLower();
            addressesQuery = addressesQuery.Where(address =>
                 (address.Street != null && address.Street.ToLower().Contains(filter.Search)) ||
                 (address.BuildingNumber != null && address.BuildingNumber.ToLower().Contains(filter.Search)) ||
                 address.City.Name.Contains(filter.Search));
            
        }
        if (filter.MaximumLatitude is not null)
            addressesQuery = addressesQuery.Where(address =>
                address.Latitude != null && address.Latitude <= filter.MaximumLatitude);
        if (filter.MinimumLatitude is not null)
            addressesQuery = addressesQuery.Where(address =>
                address.Latitude != null && address.Latitude >= filter.MinimumLatitude);
        if (filter.MaximumLongitude is not null)
            addressesQuery = addressesQuery.Where(address =>
                address.Longitude != null && address.Longitude <= filter.MaximumLongitude);
        if (filter.MinimumLongitude is not null)
            addressesQuery = addressesQuery.Where(address =>
                address.Longitude != null && address.Longitude >= filter.MinimumLongitude);
        #endregion

        return await addressesQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Address> UpdateAsync(long id, Address address, CancellationToken cancellationToken = default)
    {
        await validator.ValidateOrPanicAsync(address);
        // generating address string
        await GenerateAddressStringAsync(address);
        var updatedEntity = await repository.UpdateAsync(addr => addr.Id == id, address,
            shouldThrowException: true,
            cancellationToken: cancellationToken);
        return updatedEntity;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync<Address>(address => address.Id == id,
            shouldThrowException: true,
            cancellationToken: cancellationToken);
        return true;
    }
}