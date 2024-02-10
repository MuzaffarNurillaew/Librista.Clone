using FluentValidation;
using Librista.Domain.Entities;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Validators;

public class BorrowingRecordValidator : AbstractValidator<BorrowingRecord>
{
    public BorrowingRecordValidator(ValidationUtilities utilities)
    {
        
    }
}