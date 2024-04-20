using System.ComponentModel.DataAnnotations.Schema;
using StudyMate.Domain.Common.Entities;
using StudyMate.Domain.Enums;

namespace StudyMate.Domain.Entities;

public abstract class Answer : IEntity
{
    public Guid Id { get; set; }

    public Guid QuestionId { get; set; }

    public QuestionType Type { get; set; }
    
    public Question Question { get; set; } = default!;
}