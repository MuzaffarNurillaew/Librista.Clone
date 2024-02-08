using System.Linq.Expressions;
using Librista.Domain.Commons;

namespace Librista.Data.Repositories;

public interface IRepository<T> where T : Auditable
{
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
    Task InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    
    Task<T> SelectAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression);
    
    Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T entity, CancellationToken cancellationToken = default);
    
    Task<T> DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}