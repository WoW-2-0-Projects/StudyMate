using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Domain.Entities;

public class TrueFalseQuestion : Question
{
    [NotMapped]
    public new TrueFalseQuestionAnswer Answer
    {
        get => (TrueFalseQuestionAnswer)base.Answer;
        set => base.Answer = value;
    }
}