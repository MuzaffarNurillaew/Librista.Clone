using System.Linq.Expressions;

namespace Librista.Data.Repositories.JoiningEntities;

public interface IJoiningEntityRepository
{
    Task<T> InsertAsync<T>(T entity, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : class;
    Task InsertManyAsync<T>(IEnumerable<T> entities, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : class;
    
    Task<T> SelectAsync<T>(Expression<Func<T, bool>> expression, bool shouldThrowException = false, bool shouldTrack = true, string[]? includes = null, CancellationToken cancellationToken = default)
        where T : class;
    IQueryable<T> SelectAll<T>(Expression<Func<T, bool>> expression, string[]? includes = null)
        where T : class;
    
    Task<T> UpdateAsync<T>(Expression<Func<T, bool>> expression,
        T entity,
        bool shouldThrowException = false,
        bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class;

    Task<bool> DestroyAsync<T>(Expression<Func<T, bool>> expression, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : class;

    Task DestroyManyAsync<T>(Expression<Func<T, bool>> expression, bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : class;
}