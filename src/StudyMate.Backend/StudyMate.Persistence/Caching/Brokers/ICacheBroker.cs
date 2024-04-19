using StudyMate.Persistence.Caching.Models;

namespace StudyMate.Persistence.Caching.Brokers;

/// <summary>
/// Defines cache broker functionaility.
/// </summary>
public interface ICacheBroker
{
    /// <summary>
    /// Gets the cache entry value with specified key.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if it's found, otherwise default value.</returns>
    ValueTask<T?> GetAsync<T>(
        string key,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry value with specified key.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="value">Cached entry value if found, otherwise default value.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>True if the cache enrty value is found and retrieved successfully, otherwise False.</returns>
    ValueTask<bool> TryGetAsync<T>(
        string key,
        out T value,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry value with specified key.
    /// If it's not found, sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="value">Cached entry value if found, otherwise default value.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if it's found, otherwise default value.</returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        T value,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry value with specified key.
    /// If it's not found, sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if it's found, otherwise default value.</returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<T> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry value with specified key.
    /// If it's not found, sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if it's found, otherwise default value.</returns>
    /// <returns></returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="value">Cached entry value if found, otherwise default value.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns></returns>
    ValueTask SetAsync<T>(
        string key,
        T value,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns></returns>
    ValueTask SetAsync<T>(
        string key,
        Func<T> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the cache entry with specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set.</param>
    /// <param name="entryOptions">A cache entry options to specify caching options.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns></returns>
    ValueTask SetAsync<T>(
        string key,
        Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the cache entry with specified key.
    /// </summary>
    /// <param name="key">The key of cache entry.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns></returns>
    ValueTask DeleteAsync(
        string key,
        CancellationToken cancellationToken = default);
}
