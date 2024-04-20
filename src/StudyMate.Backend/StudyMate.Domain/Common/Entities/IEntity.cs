namespace StudyMate.Domain.Common.Entities;

/// <summary>
/// Defines an entity within the system.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the entity Id.
    /// </summary>
    public Guid Id { get; set; }
}