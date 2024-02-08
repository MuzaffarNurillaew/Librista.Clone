using System.Linq.Expressions;
using Librista.Domain.Commons;

namespace Librista.Data.Repositories;

/// <inheritdoc />
public class Repository<T> : IRepository<T> where T : Auditable
{
    public Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> SelectAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}