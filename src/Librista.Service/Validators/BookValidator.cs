using System.Data;
using FluentValidation;
using Librista.Domain.Entities;
using Librista.Service.Validators.Utilities;

namespace Librista.Service.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator(ValidationUtilities utilities)
    {
        RuleFor(book => book.GenreId)
            .MustAsync(async (genreId, _) => await utilities.ExistsAsync<Genre>(genreId, shouldThrowException: true));
        
        RuleFor(book => book.PublisherId)
            .MustAsync(async (publisherId, _) => await utilities.ExistsAsync<Publisher>(publisherId, shouldThrowException: true));
        
        RuleFor(book => book.Isbn)
            .Must(isbn =>
            {
                isbn = isbn.Replace("-", "");
                return IsValidIsbn(isbn);
            }).WithMessage("Isbn of the book is invalid.");
        
        RuleFor(book => book.Isbn)
            .MustAsync(async (isbn, _) =>
                !await utilities.ExistsAsync<Book>(book => book.Isbn == isbn))
            .WithMessage("Isbn of the book already exists.");

        RuleFor(book => book.Title)
            .Must(title => !string.IsNullOrWhiteSpace(title) && title.Length < 81 && title.Length > 1);

        RuleFor(book => book.Summary)
            .Must(summary =>
                summary is null || (!string.IsNullOrWhiteSpace(summary) && summary.Length is > 15 and < 501));
        
        RuleFor(book => book.Chapters)
            .Must(chapter =>
                chapter is null || (!string.IsNullOrWhiteSpace(chapter) && chapter.Length is > 15 and < 501));
        
        RuleFor(book => book.LeftCount)
            .Must(count => count >= 0);
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        When(book => book.Authors is not null && book.Authors.Count != 0,
            () =>
            {
                RuleForEach(book => book.Authors)
                    .MustAsync(async (author, _)
                        => await utilities.ExistsAsync<Author>(author.Id));
            });
        
    }
    
    // Taken from: https://www.geeksforgeeks.org/program-check-isbn/
    private static bool IsValidIsbn(string isbn) 
    {
        // length must be 10 
        int len = isbn.Length; 
        if (len != 10) 
            return false; 
  
        // Computing weighted sum of  
        // first 9 digits 
        var sum = 0; 
        for (var i = 0; i < 9; i++) 
        { 
            var digit = isbn[i] - '0'; 
              
            if (digit is < 0 or > 9) 
                return false; 
                  
            sum += digit * (10 - i); 
        } 
  
        // checking last digit. 
        var last = isbn[9]; 
        if (last != 'X' && last is < '0' or > '9') 
            return false; 
  
        // if last digit is 'X', add 10 to sum, else add its value. 
        sum += last == 'X' ? 10 : last - '0'; 
  
        // return true if weighted sum of digits is divisible by 11. 
        return sum % 11 == 0; 
    } 
}