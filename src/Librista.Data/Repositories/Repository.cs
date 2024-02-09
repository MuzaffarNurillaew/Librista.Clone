using System.Linq.Expressions;
using Librista.Data.Contexts;
using Librista.Domain.Commons;
using Librista.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Librista.Data.Repositories;

/// <inheritdoc />
public class Repository(LibristaContext context) : IRepository
{
    public async Task<T> InsertAsync<T>(T entity, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var insertedEntity = await set.AddAsync(entity, cancellationToken);
        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        return insertedEntity.Entity;
    }

    public async Task InsertManyAsync<T>(IEnumerable<T> entities, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        await set.AddRangeAsync(entities, cancellationToken);
        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<T> SelectAsync<T>(Expression<Func<T, bool>> expression, bool shouldThrowException = false, bool shouldTrack = true, string[]? includes = null, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entityQuery = set.Where(expression);
        // throws exception if not found
        if (!await entityQuery.AnyAsync(cancellationToken: cancellationToken) && shouldThrowException)
            throw new NotFoundException<T>();
        entityQuery = shouldTrack ? entityQuery.AsTracking() : entityQuery.AsNoTracking();
        if (includes is not null && includes.Length != 0)
        {
            foreach (var include in includes)
            {
                entityQuery = entityQuery.Include(include);
            }
        }

        return (await entityQuery.FirstOrDefaultAsync(cancellationToken))!;
    }

    public IQueryable<T> SelectAll<T>(Expression<Func<T, bool>> expression, string[]? includes = null)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entityQuery = set.Where(expression);
        if (includes is not null && includes.Length != 0)
        {
            foreach (var include in includes)
            {
                entityQuery = entityQuery.Include(include);
            }
        }

        return entityQuery;
    }

    public async Task<T> UpdateAsync<T>(Expression<Func<T, bool>> expression, T entity, bool shouldThrowException = false, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entityToUpdate = await SelectAsync(expression, shouldThrowException: shouldThrowException, cancellationToken: cancellationToken);
        context.Entry(entity: entityToUpdate).CurrentValues.SetValues(entity);

        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        return entityToUpdate;
    }

    public async Task<T> DeleteAsync<T>(Expression<Func<T, bool>> expression, bool shouldThrowException = false, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entityToDelete = await set.FirstOrDefaultAsync(expression, cancellationToken);
        if (entityToDelete is null && shouldThrowException)
        {
            throw new NotFoundException<T>();
        }
        if (entityToDelete is not null)
        {
            entityToDelete.IsDeleted = true;
            entityToDelete.DeletedDate = DateService.Now();
        }

        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        return entityToDelete!;
    }
    
    public async Task DeleteManyAsync<T>(Expression<Func<T, bool>> expression, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entitiesToDelete = await set.Where(expression).ToListAsync(cancellationToken);
        entitiesToDelete.ForEach(entity =>
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateService.Now();
        });
        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<bool> DestroyAsync<T>(Expression<Func<T, bool>> expression, bool shouldSave = true, CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entityToDestroy = await set.FirstOrDefaultAsync(expression, cancellationToken);

        if (entityToDestroy is null)
        {
            return false;
        }
        
#pragma warning disable CS8634
        context.Remove(entityToDestroy);
#pragma warning restore CS8634

        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }

    public async Task DestroyManyAsync<T>(Expression<Func<T, bool>> expression, bool shouldSave = true,
        CancellationToken cancellationToken = default)
        where T : Auditable
    {
        var set = context.Set<T>();
        var entitiesToDestroy = await set.Where(expression).ToListAsync(cancellationToken);

        
#pragma warning disable CS8634
        context.RemoveRange(entitiesToDestroy);
#pragma warning restore CS8634

        if (shouldSave)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
