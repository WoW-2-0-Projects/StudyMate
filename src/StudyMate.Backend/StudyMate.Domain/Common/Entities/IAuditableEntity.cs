namespace StudyMate.Domain.Common.Entities;

/// <summary>
/// Defines an entity that created and modified time can be tracked.
/// </summary>
public interface IAuditableEntity : ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedTime { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// Can be null if the entity has never been modified.
    /// </summary>
    public DateTimeOffset? ModifiedTime { get; set; }
}