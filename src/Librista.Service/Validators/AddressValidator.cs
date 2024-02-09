using System.Data;
using FluentValidation;
using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator(ValidationUtilities utilities)
    {
        RuleFor(address => address.Street)
            .Must(street => street is null || street.Length > 0);
        RuleFor(address => address.BuildingNumber)
            .Must(buildingNumber => buildingNumber is null || buildingNumber.Length > 0);
        RuleFor(address => address.CityId)
            .MustAsync(async (cityId, _) => await utilities.ExistsAsync<City>(cityId, shouldThrowException: true));
        RuleFor(address => address.Longitude)
            .Must(lon => lon is null or > -181 and < 180);
        RuleFor(address => address.Latitude)
            .Must(lon => lon is null or > -181 and < 180);
    }
}

public class PublisherValidator : AbstractValidator<Publisher>
{
    public PublisherValidator(ValidationUtilities utilities)
    {
        RuleFor(publisher => publisher.AddressId)
            .MustAsync(async (publisherId, _) => await utilities.ExistsAsync<Publisher>(publisherId, shouldThrowException: true));
        RuleFor(publisher => publisher.Name)
            .Must(name => name is null || name.Length > 0);
            
    }
}