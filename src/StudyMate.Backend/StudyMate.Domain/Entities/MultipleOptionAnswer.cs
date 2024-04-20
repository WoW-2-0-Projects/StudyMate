using StudyMate.Domain.Common.Entities;

namespace StudyMate.Domain.Entities;

/// <summary>
/// Represents an answer to a multiple-choice question.
/// </summary>
public class MultipleOptionAnswer : IEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the question this answer corresponds to.
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    /// Gets or sets the selected answers for the question.
    /// </summary>
    public List<string> Answers { get; set; } = default!;
}