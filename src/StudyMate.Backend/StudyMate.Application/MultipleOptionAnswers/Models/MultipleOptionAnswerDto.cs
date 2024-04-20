namespace StudyMate.Application.MultipleOptionAnswers.Models;

/// <summary>
/// Data transfer object (DTO) representing a multiple-choice answer for a question.
/// </summary>
public class MultipleOptionAnswerDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the multiple-choice answer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the question associated with this answer.
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    /// Gets or sets the list of answers provided for the question.
    /// </summary>
    public List<string> Answers { get; set; } = default!;
}
