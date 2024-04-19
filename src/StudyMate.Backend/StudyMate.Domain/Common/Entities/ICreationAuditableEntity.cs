namespace StudyMate.Domain.Common.Entities;

/// <summary>
/// Defines an entity that the user created can be tracked.
/// </summary>
public interface ICreationAuditableEntity
{
    /// <summary>
    /// Gets or sets the ID of the user who created the entity.
    /// </summary>
    Guid CreatedByUserId { get; set; }
}