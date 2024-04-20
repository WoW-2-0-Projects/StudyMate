using System.Windows.Input;
using StudyMate.Application.MultipleOptionAnswers.Models;
using StudyMate.Domain.Common.Queries;

namespace StudyMate.Application.MultipleOptionAnswers.Queries;

public class GetMultipleOptionAnswerQuery:IQuery<ICollection<MultipleOptionAnswerDto>>
{
    public MultipleOptionAnswerFilterModel FilterModel { get; set; } = default!;
}