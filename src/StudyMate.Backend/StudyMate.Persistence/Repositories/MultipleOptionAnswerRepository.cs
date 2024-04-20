using System.Linq.Expressions;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;
using StudyMate.Persistence.DataContexts;
using StudyMate.Persistence.Repositories.Interfaces;

namespace StudyMate.Persistence.Repositories;

/// <summary>
/// Provides multiple-choice answer repository functionality.
/// </summary>
public class MultipleOptionAnswerRepository(AppDbContext appDbContext)
    : EntityRepositoryBase<MultipleOptionAnswer, AppDbContext>(appDbContext), IMultipleOptionAnswerRepository
{
    public new IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default,
        QueryOptions queryOptions = default)
        => base.Get(predicate, queryOptions);

    public new ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswerId,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(multipleOptionAnswerId, queryOptions, cancellationToken);

    public new ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
        => base.CreateAsync(multipleOptionAnswer, commandOptions, cancellationToken);

    public new ValueTask<MultipleOptionAnswer> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
        => base.UpdateAsync(multipleOptionAnswer, commandOptions, cancellationToken);

    public new ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(multipleOptionAnswerId, commandOptions, cancellationToken);
}