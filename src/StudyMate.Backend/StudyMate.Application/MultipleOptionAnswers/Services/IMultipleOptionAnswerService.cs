using System.Linq.Expressions;
using StudyMate.Application.MultipleOptionAnswers.Models;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;

namespace StudyMate.Application.MultipleOptionAnswers.Service;

/// <summary>
/// Service interface for managing multiple-option answers.
/// </summary>
public interface IMultipleOptionAnswerService
{
    /// <summary>
    /// Retrieves multiple-option answers based on a predicate and query options asynchronously.
    /// </summary>
    /// <param name="predicate">Optional predicate to filter the results.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <returns>An IQueryable of MultipleOptionAnswer.</returns>
    IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default,
                                         QueryOptions queryOptions = default);

    /// <summary>
    /// Retrieves multiple-option answers based on a filter model and query options asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswerFilterModel">The filter model to apply.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <returns>An IQueryable of MultipleOptionAnswer.</returns>
    IQueryable<MultipleOptionAnswer> Get(MultipleOptionAnswerFilterModel multipleOptionAnswerFilterModel,
                                         QueryOptions queryOptions = default);

    /// <summary>
    /// Retrieves a multiple-option answer by its unique identifier asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The unique identifier of the multiple-option answer.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask containing the MultipleOptionAnswer or null if not found.</returns>
    ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswerId, QueryOptions queryOptions = default,
                                                  CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new multiple-option answer asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The multiple-option answer to create.</param>
    /// <param name="commandOptions">Command options for the operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask containing the created MultipleOptionAnswer.</returns>
    ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                CommandOptions commandOptions = default,
                                                CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing multiple-option answer asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The multiple-option answer to update.</param>
    /// <param name="commandOptions">Command options for the operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask containing the updated MultipleOptionAnswer or null if not found.</returns>
    ValueTask<MultipleOptionAnswer?> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                 CommandOptions commandOptions = default,
                                                 CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a multiple-option answer by its unique identifier asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The unique identifier of the multiple-option answer to delete.</param>
    /// <param name="commandOptions">Command options for the operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A ValueTask containing the deleted MultipleOptionAnswer or null if not found.</returns>
    ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId,
                                                     CommandOptions commandOptions = default,
                                                     CancellationToken cancellationToken = default);
}