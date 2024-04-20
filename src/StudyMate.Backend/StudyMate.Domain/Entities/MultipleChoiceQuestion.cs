using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Domain.Entities;

public class MultipleChoiceQuestion : Question
{
    [NotMapped]
    public new MultipleChoiceQuestionAnswer Answer
    {
        get => (MultipleChoiceQuestionAnswer)base.Answer;
        set => base.Answer = value;
    }
}