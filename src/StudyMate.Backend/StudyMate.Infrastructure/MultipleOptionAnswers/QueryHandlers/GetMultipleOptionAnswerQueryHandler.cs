using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyMate.Application.MultipleOptionAnswers.Models;
using StudyMate.Application.MultipleOptionAnswers.Queries;
using StudyMate.Application.MultipleOptionAnswers.Service;
using StudyMate.Domain.Common.Queries;

namespace StudyMate.Infrastructure.MultipleOptionAnswers.QueryHandlers;

public class GetMultipleOptionAnswerQueryHandler(IMultipleOptionAnswerService multipleOptionAnswerService,IMapper mapper):IQueryHandler<GetMultipleOptionAnswerQuery,ICollection<MultipleOptionAnswerDto>>
{
    public async Task<ICollection<MultipleOptionAnswerDto>> Handle(GetMultipleOptionAnswerQuery request, CancellationToken cancellationToken)
    {
        var matchedCustomerFeedback = 
            await multipleOptionAnswerService
                  .Get(request.FilterModel, 
                      new QueryOptions() { QueryTrackingMode = QueryTrackingMode.AsNoTracking }).ToListAsync(cancellationToken);
        
        return mapper.Map<ICollection<MultipleOptionAnswerDto>>(matchedCustomerFeedback);
    }
}