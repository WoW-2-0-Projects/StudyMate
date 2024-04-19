namespace StudyMate.Domain.Common.Entities;

/// <summary>
/// Defines an entity that can be soft deleted.
/// </summary>
public interface ISoftDeletedEntity : IEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity has been soft deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was soft deleted.
    /// </summary>
    public DateTimeOffset? DeletedTime { get; set; }
}