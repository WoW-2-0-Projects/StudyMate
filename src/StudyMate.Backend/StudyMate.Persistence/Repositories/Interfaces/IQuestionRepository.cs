using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;

namespace StudyMate.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines question repository functionality
/// </summary>
public interface IQuestionRepository
{
    /// <summary>
    /// Gets a queryable source of question entities based on an optional predicate and query options.
    /// </summary>
    /// <param name="predicate">Optional predicate to filter questions.</param>
    /// <param name="queryOptions">Query options</param>
    /// <returns>Queryable source of question entities</returns>
    IQueryable<Question> Get(Expression<Func<Question, bool>>? predicate = default, QueryOptions queryOptions = default);

    /// <summary>
    /// Gets a single question by its id.
    /// </summary>
    /// <param name="questionId">The unique identifier of the question.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Question if found, otherwise null</returns>
    ValueTask<Question?> GetByIdAsync(Guid questionId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);
    
    
    /// <summary>
    /// Creates a new question entity.
    /// </summary>
    /// <param name="question">The question entity to create.</param>
    /// <param name="commandOptions">Command options for the creation process.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created question entity.</returns>
    ValueTask<Question> CreateAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an existing user entity.
    /// </summary>
    /// <param name="question">The question entity to update.</param>
    /// <param name="commandOptions">Command options for the update process.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated question entity.</returns>
    ValueTask<Question> UpdateAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a question entity by its id.
    /// </summary>
    /// <param name="questionId">The unique identifier of the question to delete.</param>
    /// <param name="commandOptions">Command options for the delete operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The deleted question entity if soft deleted, otherwise null.</returns>
    ValueTask<Question?> DeleteByIdAsync(Guid questionId, CommandOptions commandOptions, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a question
    /// </summary>
    /// <param name="question">The question to be deleted.</param>
    /// <param name="commandOptions">Delete command options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated question if soft deleted, otherwise null</returns>
    ValueTask<Question?> DeleteAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
}