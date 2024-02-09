using FluentValidation;
using Librista.Domain.Entities;

namespace Librista.Service.Validators;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(genre => genre.Name)
            .Must(name => name.Length < 21 && !string.IsNullOrWhiteSpace(name));
    }
}