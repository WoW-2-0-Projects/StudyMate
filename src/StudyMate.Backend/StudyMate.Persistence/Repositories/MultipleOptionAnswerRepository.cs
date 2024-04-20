using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;
using StudyMate.Persistence.DataContexts;
using StudyMate.Persistence.Repositories.Interfaces;

namespace StudyMate.Persistence.Repositories;

/// <summary>
/// Repository class for managing multiple-choice answers in the database.
/// Inherits from EntityRepositoryBase for generic CRUD operations and implements IMultipleOptionAnswerRepository.
/// </summary>
public class MultipleOptionAnswerRepository(AppDbContext appDbContext)
    : EntityRepositoryBase<MultipleOptionAnswer, AppDbContext>(appDbContext), IMultipleOptionAnswerRepository
{
    /// <summary>
    /// Retrieves multiple-choice answers based on optional filter predicate and query options.
    /// </summary>
    /// <param name="predicate">Optional filter predicate.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <returns>An IQueryable of MultipleOptionAnswer entities.</returns>
    public new IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default,
                                                    QueryOptions queryOptions = default)
        => base.Get(predicate, queryOptions);

    /// <summary>
    /// Retrieves a multiple-choice answer by its unique identifier asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The ID of the multiple-choice answer to retrieve.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask containing the retrieved MultipleOptionAnswer entity.</returns>
    public new ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswer,
                                                             QueryOptions queryOptions = default,
                                                             CancellationToken cancellationToken = default)
        => base.GetByIdAsync(multipleOptionAnswer, queryOptions, cancellationToken);

    /// <summary>
    /// Creates a new multiple-choice answer asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The MultipleOptionAnswer entity to create.</param>
    /// <param name="commandOptions">Command options for operations like validation, transaction handling, etc.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask containing the created MultipleOptionAnswer entity.</returns>
    public new ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                           CommandOptions commandOptions = default,
                                                           CancellationToken cancellationToken = default)
        => base.CreateAsync(multipleOptionAnswer, commandOptions, cancellationToken);

    /// <summary>
    /// Updates an existing multiple-choice answer asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The updated MultipleOptionAnswer entity.</param>
    /// <param name="commandOptions">Command options for operations like validation, transaction handling, etc.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask containing the updated MultipleOptionAnswer entity.</returns>
    public new ValueTask<MultipleOptionAnswer?> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                            CommandOptions commandOptions = default,
                                                            CancellationToken cancellationToken = default)
        => base.UpdateAsync(multipleOptionAnswer, commandOptions, cancellationToken);

    /// <summary>
    /// Deletes a multiple-choice answer by its ID asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The ID of the multiple-choice answer to delete.</param>
    /// <param name="commandOptions">Command options for operations like validation, transaction handling, etc.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask containing the deleted MultipleOptionAnswer entity.</returns>
    public new ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId,
                                                                CommandOptions commandOptions = default,
                                                                CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(multipleOptionAnswerId, commandOptions, cancellationToken);
}