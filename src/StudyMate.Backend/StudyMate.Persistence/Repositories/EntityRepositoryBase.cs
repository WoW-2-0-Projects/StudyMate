using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Entities;
using StudyMate.Domain.Common.Queries;
using StudyMate.Persistence.Caching.Brokers;
using StudyMate.Persistence.Caching.Models;
using StudyMate.Persistence.Extensions;
using System.Linq.Expressions;

namespace StudyMate.Persistence.Repositories;

/// <summary>
/// Represents a base repository for entity with common CRUD operations.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TContext"></typeparam>
/// <param name="dbContext"></param>
/// <param name="cacheBroker"></param>
/// <param name="cacheEntryOptions"></param>
public abstract class EntityRepositoryBase<TEntity, TContext>(
    TContext dbContext,
    ICacheBroker cacheBroker,
    CacheEntryOptions? cacheEntryOptions = default)
    where TEntity : class, IAuditableEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;

    /// <summary>
    /// Retrieves enitites from repository based on optional filtering conditions and tracking prefrences.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    protected IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? predicate = default,
        bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    /// <summary>
    /// Retrieves enitites from repository based on optional filtering conditions and tracking prefrences.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="queryOptions"></param>
    /// <returns></returns>
    protected IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? predicate = default,
        QueryOptions queryOptions = default)
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery.ApplyTrackingMode(queryOptions.QueryTrackingMode);
    }

    /// <summary>
    /// Asynchronously retrieves an entity from repository by its id, optionally applying caching.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
    {
        var foundEntity = default(TEntity);

        if (cacheEntryOptions is null || !await cacheBroker.TryGetAsync<TEntity>(id.ToString(), out var cachedEntity, cancellationToken))
        {
            var initialQuery = DbContext.Set<TEntity>().AsQueryable();

            initialQuery.ApplyTrackingMode(queryOptions.QueryTrackingMode);

            foundEntity = await initialQuery.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

            if (cacheEntryOptions is not null && foundEntity is not null)
                await cacheBroker.SetAsync(foundEntity.Id.ToString(), foundEntity, cacheEntryOptions, cancellationToken);
        }
        else
            foundEntity = cachedEntity;

        return foundEntity;
    }

    /// <summary>
    /// Checks if entity exists.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var foundEntity = await dbContext.Set<TEntity>()
            .Select(entity => entity.Id)
            .FirstOrDefaultAsync(foundEntityId => foundEntityId == id, cancellationToken);

        return foundEntity != Guid.Empty;
    }

    /// <summary>
    /// Asynchronously retrieves entities from repository by collection of ids.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = dbContext.Set<TEntity>().Where(entity => ids.Contains(entity.Id));

        initialQuery.ApplyTrackingMode(queryOptions.QueryTrackingMode);

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a new entity in repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (cacheEntryOptions is not null)
            await cacheBroker.SetAsync(entity.Id.ToString(), entity, cacheEntryOptions, cancellationToken);

        if (!commandOptions.SkipSaveChanges)
            await dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    /// <summary>
    /// Asynchronously updates a entity in repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if (cacheEntryOptions is not null)
            await cacheBroker.SetAsync(entity.Id.ToString(), entity, cacheEntryOptions, cancellationToken);

        if (!commandOptions.SkipSaveChanges)
            await dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    /// <summary>
    /// Updates entities in batch
    /// </summary>
    /// <param name="batchUpdatePredicate">Predicate to select entities for batch update</param>
    /// <param name="setPropertyCalls">Batch update value selectors</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Number of updated rows.</returns>
    protected async ValueTask<int> UpdateBatchAsync(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls,
        Expression<Func<TEntity, bool>>? batchUpdatePredicate = default,
        CancellationToken cancellationToken = default
    )
    {
        var entities = DbContext.Set<TEntity>().AsQueryable();

        if (batchUpdatePredicate is not null)
            entities = entities.Where(batchUpdatePredicate);

        return await entities.ExecuteUpdateAsync(setPropertyCalls, cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes a entity in repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected async ValueTask<TEntity?> DeleteAsync(
        TEntity entity,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (cacheEntryOptions is not null)
            await cacheBroker.DeleteAsync(entity.Id.ToString(), cancellationToken);

        if (!commandOptions.SkipSaveChanges)
            await dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    /// <summary>
    /// Asynchronously deletes an existing entity in repository by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="commandOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected async ValueTask<TEntity?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default)
    {
        var entity = await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken)
            ?? throw new InvalidOperationException();

        DbContext.Remove(entity);

        if (cacheEntryOptions is not null)
            await cacheBroker.DeleteAsync(entity.Id.ToString(), cancellationToken);

        if (!commandOptions.SkipSaveChanges)
            await dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
