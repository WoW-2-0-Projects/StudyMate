using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.Repositories.Interfaces;

public interface IMultipleOptionAnswerRepository
{
     /// <summary>
    /// Retrieves a queryable collection of customer feedback entities based on the provided predicate and query options.
    /// </summary>
    /// <param name="predicate">An optional predicate to filter the customer feedback entities.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <returns>A queryable collection of customer feedback entities.</returns>
    IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default, QueryOptions queryOptions = default);
   
    /// <summary>
    /// Retrieves a customer feedback entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The unique identifier of the customer feedback entity to retrieve.</param>
    /// <param name="queryOptions">Query options for sorting, pagination, etc.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation that returns the customer feedback entity.</returns>
    ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswer, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);


    /// <summary>
    /// Creates a new customer feedback entity asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The customer feedback entity to create.</param>
    /// <param name="commandOptions">Command options for the create operation.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation that returns the created customer feedback entity.</returns>
    ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates a customer feedback entity asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswer">The customer feedback entity to update.</param>
    /// <param name="commandOptions">Command options for the update operation.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation that returns the updated customer feedback entity.</returns>
    ValueTask<MultipleOptionAnswer?> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a customer feedback entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="multipleOptionAnswerId">The unique identifier of the customer feedback entity to delete.</param>
    /// <param name="commandOptions">Command options for the delete operation.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
}
