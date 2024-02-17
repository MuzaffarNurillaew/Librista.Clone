using Librista.Domain.Commons;
using Librista.Domain.Exceptions;
using Librista.Service.Interfaces.Filters;

namespace Librista.Service.Filters.Extensions;

public static class LogicExtensions
{
    public static IQueryable<TEntity> FilterAuditable<TEntity, TFilter>(this IQueryable<TEntity> query, TFilter filter)
        where TEntity : IAuditable
        where TFilter : IAuditableFilter
    {
        if (filter.MinimumCreationDate is not null)
        {
            query = query.Where(entity => entity.CreatedDate >= filter.MinimumCreationDate);
        }

        if (filter.MaximumCreationDate is not null)
        {
            query = query.Where(entity => entity.CreatedDate <= filter.MaximumCreationDate);
        }

        return query;
    }

    public static IQueryable<TEntity> FilterPagable<TEntity, TFilter>(this IQueryable<TEntity> query, TFilter filter)
        where TEntity : IAuditable
        where TFilter : IPagable 
    {
        if (filter.PaginationParameters is not null)
        {
            int pageSize = filter.PaginationParameters.PageSize;
            int pageIndex = filter.PaginationParameters.PageIndex;
            
            if (pageIndex < 1 || pageSize < 1)
                throw new CustomException("Please enter valid numbers to paginate content correctly.");

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        return query;
    }
}