using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Domain.Entities;

public class MultipleChoiceQuestionAnswer : Answer
{
    public List<string> Answers { get; set; } = default!;
    
    [NotMapped]
    public new MultipleChoiceQuestion Question
    {
        get => (MultipleChoiceQuestion)base.Question;
        set => base.Question = value;
    }
}