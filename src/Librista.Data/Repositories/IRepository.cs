using System.Linq.Expressions;
using Librista.Domain.Commons;

namespace Librista.Data.Repositories;

public interface IRepository
{
    Task<T> InsertAsync<T>(T entity, bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
    Task InsertManyAsync<T>(IEnumerable<T> entities,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
    
    Task<T> SelectAsync<T>(Expression<Func<T, bool>> expression,
        bool shouldThrowException = false,
        bool shouldTrack = true,
        string[]? includes = null,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
    IQueryable<T> SelectAll<T>(Expression<Func<T, bool>> expression,
        string[]? includes = null)
        where T : class, IAuditable;
    
    Task<T> UpdateAsync<T>(Expression<Func<T, bool>> expression,
        T entity,
        bool shouldThrowException = false,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
    
    Task<T> DeleteAsync<T>(Expression<Func<T, bool>> expression,
        bool shouldThrowException = false,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
    Task DeleteManyAsync<T>(Expression<Func<T, bool>> expression,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;

    Task<bool> DestroyAsync<T>(Expression<Func<T, bool>> expression,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class, IAuditable;
}