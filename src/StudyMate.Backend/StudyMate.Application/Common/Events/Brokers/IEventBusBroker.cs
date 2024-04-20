﻿using StudyMate.Domain.Common.Events;

namespace StudyMate.Application.Common.Events.Brokers;

/// <summary>
/// Interface for an event bus broker, responsible for publishing events locally or asynchronously.
/// </summary>
public interface IEventBusBroker
{
    /// <summary>
    /// Publishes an event locally.
    /// </summary>
    /// <typeparam name="TEvent">Type of the event to be published.</typeparam>
    /// <param name="event">The event to be published.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask PublishLocalAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : EventBase;

    /// <summary>
    /// Publishes an event asynchronously.
    /// </summary>
    /// <typeparam name="TEvent">Type of the event to be published.</typeparam>
    /// <param name="event">The event to be published.</param>
    /// <param name="eventOptions">Event options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the asynchronous operation (optional).</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask PublishAsync<TEvent>(TEvent @event, EventOptions eventOptions, CancellationToken cancellationToken = default) where TEvent : EventBase;
}
