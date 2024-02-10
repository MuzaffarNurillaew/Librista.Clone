using Librista.Data.Repositories;
using Librista.Domain.Entities;
using Librista.Service.Filters;
using Librista.Service.Filters.Extensions;
using Librista.Service.Interfaces;
using Librista.Service.Validators;
using Librista.Service.Validators.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Services;

public class GenreService(IRepository repository, GenreValidator genreValidator) : IGenreService
{
    public async Task<Genre> CreateAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        await genreValidator.ValidateOrPanicAsync(genre);
        var insertedEntity = await repository.InsertAsync(entity: genre,
            cancellationToken: cancellationToken);

        return insertedEntity;
    }

    public async Task<Genre> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Genre.Books) } : null;
        var entity = await repository.SelectAsync<Genre>(genre => genre.Id == id,
            shouldThrowException: throwException,
            shouldTrack: track,
            includes: includes,
            cancellationToken: cancellationToken);

        return entity;
    }

    public async Task<List<Genre>> GetAllAsync(GenreFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default)
    {
        var includes = loadRelations ? new[] { nameof(Genre.Books) } : null;
        var genresQuery = repository.SelectAll<Genre>(genre => true,
            includes: includes);

        #region Filtering

        if (filter.Search is not null)
        {
            genresQuery = genresQuery.Where(genre =>
                genre.Name.ToLower().Contains(filter.Search.ToLower()));
        }

        genresQuery
            .FilterAuditable(filter)
            .FilterPagable(filter);

        #endregion

        if (!track)
        {
            genresQuery = genresQuery.AsNoTracking();
        }
        return await genresQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Genre> UpdateAsync(long id,
        Genre genre,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        await genreValidator.ValidateOrPanicAsync(genre);
        var updatedGenre = await repository.UpdateAsync<Genre>(gnre => gnre.Id == id,
            entity: genre,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken);
        return updatedGenre;
    }

    public async Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default)
    {
        var deletedEntity = await repository.DeleteAsync<Genre>(genre => genre.Id == id,
            shouldThrowException: throwException,
            shouldSave: true,
            cancellationToken: cancellationToken
        );
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return deletedEntity is not null;
    }
}