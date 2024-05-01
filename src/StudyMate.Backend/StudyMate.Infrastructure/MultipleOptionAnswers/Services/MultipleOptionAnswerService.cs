using System.Linq.Expressions;
using AutoMapper;
using StudyMate.Application.MultipleOptionAnswers.Models;
using StudyMate.Application.MultipleOptionAnswers.Service;
using StudyMate.Domain.Common.Commands;
using StudyMate.Domain.Common.Queries;
using StudyMate.Domain.Entities;
using StudyMate.Persistence.Extensions;
using StudyMate.Persistence.Repositories.Interfaces;

namespace StudyMate.Infrastructure.MultipleOptionAnswers.Services;

public class MultipleOptionAnswerService(IMultipleOptionAnswerRepository service)
    : IMultipleOptionAnswerService
{
    public IQueryable<MultipleOptionAnswer> Get(Expression<Func<MultipleOptionAnswer, bool>>? predicate = default,
                                                QueryOptions queryOptions = default)
        => service.Get(predicate, queryOptions);

    public IQueryable<MultipleOptionAnswer> Get(MultipleOptionAnswerFilterModel multipleOptionAnswerFilterModel,
                                                QueryOptions queryOptions = default)
        => service.Get(queryOptions: queryOptions).ApplyPagination(multipleOptionAnswerFilterModel);


    public ValueTask<MultipleOptionAnswer?> GetByIdAsync(Guid multipleOptionAnswerId,
                                                         QueryOptions queryOptions = default,
                                                         CancellationToken cancellationToken = default)
        => service.GetByIdAsync(multipleOptionAnswerId, queryOptions, cancellationToken);

    public ValueTask<MultipleOptionAnswer> CreateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                       CommandOptions commandOptions = default,
                                                       CancellationToken cancellationToken = default)
        => service.CreateAsync(multipleOptionAnswer, commandOptions, cancellationToken);

    public async ValueTask<MultipleOptionAnswer?> UpdateAsync(MultipleOptionAnswer multipleOptionAnswer,
                                                              CommandOptions commandOptions = default,
                                                              CancellationToken cancellationToken = default)
    {
        var foundmultipleOptionAnswer =
            await service.GetByIdAsync(multipleOptionAnswer.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException($"Customer feedback not found {nameof(multipleOptionAnswer)}");

        foundmultipleOptionAnswer.Answers = multipleOptionAnswer.Answers;
        foundmultipleOptionAnswer.QuestionId = foundmultipleOptionAnswer.QuestionId;

        return await service.UpdateAsync(foundmultipleOptionAnswer, commandOptions, cancellationToken);
    }

    public ValueTask<MultipleOptionAnswer?> DeleteByIdAsync(Guid multipleOptionAnswerId,
                                                            CommandOptions commandOptions = default,
                                                            CancellationToken cancellationToken = default)
        => service.DeleteByIdAsync(multipleOptionAnswerId, commandOptions, cancellationToken);
}