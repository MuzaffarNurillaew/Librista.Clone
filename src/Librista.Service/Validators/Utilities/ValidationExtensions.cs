using FluentValidation;
using FluentValidation.Results;
using ValidationException = Librista.Domain.Exceptions.ValidationException;

namespace Librista.Service.Validators.Utilities;

public static class ValidationExtensions
{
    public static async Task<ValidationResult> ValidateOrPanicAsync<TValidator, TObject>(this TValidator validator,
        TObject @object)
        where TObject : class
        where TValidator : AbstractValidator<TObject>
    {
        var validationResult = await validator.ValidateAsync(@object);
        if (validationResult.Errors.Count != 0)
            throw new ValidationException(validationResult.Errors);

        return validationResult;
    }
}