using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;
using StudyMate.Persistence.DataContexts;
using StudyMate.Persistence.Repositories.Interfaces;

namespace StudyMate.Persistence.Repositories;

/// <summary>
/// Provides question repository functionality
/// </summary>
public class QuestionRepository(AppDbContext dbContext) : EntityRepositoryBase<Question, AppDbContext>(dbContext), IQuestionRepository
{
    public new IQueryable<Question> Get(Expression<Func<Question, bool>>? predicate = default, QueryOptions queryOptions = default)
        => base.Get(predicate, queryOptions);

    public new ValueTask<Question?> GetByIdAsync(Guid questionId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(questionId, queryOptions, cancellationToken);

    public new ValueTask<Question> CreateAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
        => base.CreateAsync(question, commandOptions, cancellationToken);

    public new ValueTask<Question> UpdateAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
        => base.UpdateAsync(question, commandOptions, cancellationToken);

    public new ValueTask<Question?> DeleteByIdAsync(Guid questionId, CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(questionId, commandOptions, cancellationToken);

    public new ValueTask<Question?> DeleteAsync(Question question, CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
        => base.DeleteAsync(question, commandOptions, cancellationToken);
}