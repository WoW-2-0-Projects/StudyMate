using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Domain.Entities;

public class TrueFalseQuestionAnswer : Answer
{
    public bool Answer { get; set; }
    
    [NotMapped]
    public new TrueFalseQuestion Question
    {
        get => (TrueFalseQuestion)base.Question;
        set => base.Question = value;
    }
}