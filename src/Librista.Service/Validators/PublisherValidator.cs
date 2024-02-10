using System.Data;
using FluentValidation;
using Librista.Domain.Entities;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Validators;

public class PublisherValidator : AbstractValidator<Publisher>
{
    public PublisherValidator(ValidationUtilities utilities)
    {
        RuleFor(publisher => publisher.AddressId)
            .MustAsync(async (addressId, _) => await utilities.ExistsAsync<Address>(addressId, shouldThrowException: true));
        RuleFor(publisher => publisher.Name)
            .Must(name => name is null || name.Length > 0);
    }
}

public class BorrowingRecordValidator : AbstractValidator<BorrowingRecord>
{
    public BorrowingRecordValidator()
    {
        
    }
}
public class ClientValidator : AbstractValidator<ClientValidator>
{
    public ClientValidator()
    {
        
    }
}