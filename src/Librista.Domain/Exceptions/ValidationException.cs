using FluentValidation.Results;

namespace Librista.Domain.Exceptions;

public class ValidationException : Exception
{
    public const int Code = 400;
    public List<ValidationFailure> Errors { get; set; }
    
    public ValidationException(List<ValidationFailure> errors)
    {
        Errors = errors;
    }
}