using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines multiple option answer repository functionality.
/// </summary>
public interface IMultipleOptionAnswerRepository
{
    /// <summary>
    /// Gets a queryable collection of multiple option answers based on the provided predicate and query options.
    /// </summary>
    /// <param name="predicate">An optional predicate to filter the multiple option answers.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <returns>A queryable collection of multiple option answers.</returns>
    IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default, QueryOptions queryOptions = default);

    /// <summary>
    /// Gets a multiple option answer by its Id.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The Id of the multiple option answer to get.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The multiple option answer, or null if not found.</returns>
    ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswerId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new multiple option answer.
    /// </summary>
    /// <param name="multipleOptionAnswer">The multiple option answer to create.</param>
    /// <param name="commandOptions">Command options for the create operation.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The created multiple option answer.</returns>
    ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a multiple option answer.
    /// </summary>
    /// <param name="multipleOptionAnswer">The multiple option answer to update.</param>
    /// <param name="commandOptions">Command options for the update operation.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The updated multiple option answer</returns>
    ValueTask<MultipleOptionAnswer> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a multiple option answer by its Id.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The Id of the multiple option answer to delete.</param>
    /// <param name="commandOptions">Command options for the delete operation.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The deleted multiple option answer if soft deleted, otherwise null.</returns>
    ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
}