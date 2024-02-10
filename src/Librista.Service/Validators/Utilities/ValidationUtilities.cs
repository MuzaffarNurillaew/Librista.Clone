using System.Linq.Expressions;
using Librista.Data.Contexts;
using Librista.Domain.Commons;
using Librista.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Librista.Service.Validators.Utilities;

public class ValidationUtilities(LibristaContext context)
{
    public async Task<bool> ExistsAsync<T>(long id, bool shouldThrowException = false)
        where T : Auditable
    {
        var exists = await context.Set<T>().Where(entity => entity.Id == id).AnyAsync();
        return exists switch
        {
            true => true,
            false when shouldThrowException => throw new NotFoundException<T>(id),
            _ => false
        };
    }
    public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> expression, bool shouldThrowException = false)
        where T : Auditable
    {
        var exists = await context.Set<T>().Where(expression).AnyAsync();
        return exists switch
        {
            true => true,
            false when shouldThrowException => throw new NotFoundException<T>(),
            _ => false
        };
    }
}