using FluentValidation;
using Librista.Domain.Entities;

namespace Librista.Service.Validators;

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