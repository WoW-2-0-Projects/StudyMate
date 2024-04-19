namespace StudyMate.Persistence.Caching.Models;

/// <summary>
/// Reprsents the options for configuring cache entry behavior.
/// </summary>
/// <param name="absoluteExpirationRelativeToNow"></param>
/// <param name="slidingExpiration"></param>
public readonly struct CacheEntryOptions(TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration)
{
    /// <summary>
    /// Gets or sets absolute expiration time relative to the current moment.
    /// </summary>
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; } = absoluteExpirationRelativeToNow;

    /// <summary>
    /// Gets or sets sliding expiration time for cached items.
    /// </summary>
    public TimeSpan? SlidingExpiration { get; } = slidingExpiration;
}
