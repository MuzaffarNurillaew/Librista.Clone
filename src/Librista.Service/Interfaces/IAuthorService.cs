using Librista.Domain.Entities;
using Librista.Service.Filters;

namespace Librista.Service.Interfaces;

public interface IAuthorService
{
    Task<Author> CreateAsync(Author author,
        CancellationToken cancellationToken = default);
    Task<Author> GetAsync(long id,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<List<Author>> GetAllAsync(AuthorFilter filter,
        bool loadRelations = false,
        bool throwException = true,
        bool track = false,
        CancellationToken cancellationToken = default);
    
    Task<Author> UpdateAsync(long id,
        Author author,
        bool throwException = true,
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(long id,
        bool throwException = true,
        CancellationToken cancellationToken = default);
}