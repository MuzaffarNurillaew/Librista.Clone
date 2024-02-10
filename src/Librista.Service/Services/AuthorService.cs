using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class AuthorService(IRepository repository, AuthorValidator authorValidator) : IAuthorService
{
    public async Task<Author> CreateAsync(Author author,
        CancellationToken cancellationToken = default)
    {
        await authorValidator.ValidateOrPanicAsync(author);
        var createdAuthor = await repository.InsertAsync(author,
            cancellationToken: cancellationToken);

        return createdAuthor;
    }

    public async Task<Author> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Author.Books) } : null;
        var author = await repository.SelectAsync<Author>(author => author.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return author;
    }

    public async Task<List<Author>> GetAllAsync(AuthorFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Author.Books) } : null;
        var authorsQuery = repository.SelectAll<Author>(genre => true,
            includes: includes);
        
        #region Filtering

        if (filter.Search is not null)
        {
            string search = filter.Search.ToLower();
            authorsQuery = authorsQuery.Where(author =>
                author.Name.ToLower().Contains(search) ||
                (author.Biography != null && author.Biography.ToLower().Contains(search)) ||
                author.Books.Any(book => book.Title.Contains(search)));
        }
        authorsQuery = authorsQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            authorsQuery = authorsQuery.AsNoTracking();
        }
        return await authorsQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Author> UpdateAsync(long id,
        Author author,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await authorValidator.ValidateOrPanicAsync(author);
        var updatedGenre = await repository.UpdateAsync<Author>(auth => auth.Id == id,
            entity: author,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<Author>(author => author.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }
}