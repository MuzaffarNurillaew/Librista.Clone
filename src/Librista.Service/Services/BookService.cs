using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class BookService(IRepository repository, BookValidator bookValidator) : IBookService
{
    public async Task<Book> CreateAsync(Book book,
        CancellationToken cancellationToken = default)
    {
        await bookValidator.ValidateOrPanicAsync(book);
        var createdBook = await repository.InsertAsync(book,
            cancellationToken: cancellationToken);

        return createdBook;
    }

    public async Task<Book> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[]
        {
            nameof(Book.Authors),
            nameof(Book.BorrowingRecords),
            nameof(Book.Publisher),
            nameof(Book.Genre)
        } : null;
        
        var book = await repository.SelectAsync<Book>(book => book.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return book;
    }

    public async Task<List<Book>> GetAllAsync(BookFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[]
        {
            nameof(Book.Authors),
            nameof(Book.BorrowingRecords),
            nameof(Book.Publisher),
            nameof(Book.Genre)
        } : null;
        var booksQuery = repository.SelectAll<Book>(genre => true,
            includes: includes);
        
        #region Filtering

        if (filter.PublisherId is not null)
        {
            booksQuery = booksQuery.Where(book => book.PublisherId == filter.PublisherId);
        }
        if (filter.GenreId is not null)
        {
            booksQuery = booksQuery.Where(book => book.GenreId == filter.GenreId);
        }
        if (filter.MinimumPublicationDate is not null)
        {
            booksQuery = booksQuery.Where(book => book.PublicationDate >= filter.MinimumPublicationDate);
        }
        if (filter.MaximumCreationDate is not null)
        {
            booksQuery = booksQuery.Where(book => book.PublicationDate <= filter.MaximumPublicationDate);
        }
        if (filter.Search is not null)
        {
            string search = filter.Search.ToLower();
            booksQuery = booksQuery.Where(book => 
                book.Summary != null && book.Summary.ToLower().Contains(search) ||
                book.Title.ToLower().Contains(search) ||
                book.Publisher.Name.ToLower().Contains(search) ||
                book.Chapters != null && book.Chapters.ToLower().Contains(search) ||
                book.Genre.Name.ToLower().Contains(search) ||
                book.Isbn.ToLower().Contains(search)
                );
        }
        
        booksQuery = booksQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            booksQuery = booksQuery.AsNoTracking();
        }
        return await booksQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Book> UpdateAsync(long id,
        Book book,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await bookValidator.ValidateOrPanicAsync(book);
        var updatedGenre = await repository.UpdateAsync<Book>(b => b.Id == id,
            entity: book,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<Book>(book => book.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }
}