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

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(author => author.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name) && name.Length is > 3 and < 51);
        RuleFor(author => author.Biography)
            .Must(biography => biography is null ||
                               (!string.IsNullOrWhiteSpace(biography) && biography.Length is > 15 and < 301));
    }
}
public class BookValidator : AbstractValidator<Author>
{
    public BookValidator()
    {
        
    }
}
public class BorrowingRecordValidator : AbstractValidator<Author>
{
    public BorrowingRecordValidator()
    {
        
    }
}
public class ClientValidator : AbstractValidator<Author>
{
    public ClientValidator()
    {
        
    }
}