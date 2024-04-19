namespace StudyMate.Domain.Common.Entities;

/// <summary>
/// Defines an entity that the user modified can be tracked.
/// </summary>
public interface IModificationAuditableEntity
{
    /// <summary>
    /// Gets or sets the ID of the user who last modified the entity.
    /// </summary>
    public Guid? ModifiedByUserId { get; set; }
}