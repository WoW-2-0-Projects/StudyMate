using FluentValidation;
using StudyMate.Domain.Entities;

namespace StudyMate.Infrastructure.MultipleOptionAnswers.Validations;

public class MultipleOptionAnswerValidator : AbstractValidator<MultipleOptionAnswer>
{
    public MultipleOptionAnswerValidator()
    {
        RuleFor(answer => answer.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(answer => answer.QuestionId).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(answer => answer.Answers).NotNull().NotEmpty();
    }
}