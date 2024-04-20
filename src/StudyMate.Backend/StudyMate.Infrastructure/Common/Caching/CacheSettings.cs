using StudyMate.Persistence.Caching.Models;

namespace StudyMate.Infrastructure.Common.Caching;

/// <summary>
/// Represents the configuration settings for caching in a system.
/// </summary>
public record CacheSettings
{
    /// <summary>
    /// Gets or sets the absolute expiration time for cached items, measured in seconds.
    /// </summary>
    public uint AbsoluteExpirationInSeconds { get; init; }

    /// <summary>
    ///Gets or sets the sliding expiration time for cached items, measured in seconds. 
    /// </summary>
    public uint SlidingExpirationInSeconds { get; init; }

    /// <summary>
    /// Maps the cache settings to cache entry options.
    /// </summary>
    /// <returns>An instance of <see cref="CacheEntryOptions"/></returns>
    public CacheEntryOptions MapToCacheEntryOptions() =>
        new CacheEntryOptions(TimeSpan.FromSeconds(AbsoluteExpirationInSeconds), TimeSpan.FromSeconds(SlidingExpirationInSeconds));
}