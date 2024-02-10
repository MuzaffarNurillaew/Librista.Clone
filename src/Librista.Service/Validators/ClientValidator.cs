using FluentValidation;
using Librista.Domain.Entities;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Validators;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator(ValidationUtilities utilities)
    {
        RuleFor(client => client.AddressId)
            .MustAsync(async (addressId, _) => await utilities.ExistsAsync<Address>(addressId));
    }
}