using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IGenreService
{
    Task<Genre> CreateAsync(Genre genre,
        CancellationToken cancellationToken = default);

    Task<Genre> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);

    Task<List<Genre>> GetAllAsync(GenreFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);

    Task<Genre> UpdateAsync(long id,
        Genre genre,
        bool throwException = true,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}