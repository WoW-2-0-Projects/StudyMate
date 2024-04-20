﻿using System.ComponentModel.DataAnnotations.Schema;
using StudyMate.Domain.Common.Entities;
using StudyMate.Domain.Enums;

namespace StudyMate.Domain.Entities;

/// <summary>
/// Represents question in the system
/// </summary>
public abstract class Question : IEntity
{
    /// <summary>
    /// Gets or sets the question identifier
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the question type
    /// </summary>
    public string TypeValue { get; set; }
    
    [NotMapped]
    public QuestionType Type
    {
        get => Enum.Parse<QuestionType>(TypeValue);
        set => TypeValue = value.ToString();
    }

    /// <summary>
    /// Gets or sets the question content
    /// </summary>
    public string QuestionContent { get; set; } = default!;

    public Answer Answer { get; set; } = default!;
}