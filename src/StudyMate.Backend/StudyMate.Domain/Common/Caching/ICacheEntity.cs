namespace StudyMate.Domain.Common.Caching;

/// <summary>
/// Defines cache entry properties.
/// </summary>
public interface ICacheEntry
{
    /// <summary>
    /// Gets or sets the cache key.
    /// </summary>
    string CacheKey { get; }
}