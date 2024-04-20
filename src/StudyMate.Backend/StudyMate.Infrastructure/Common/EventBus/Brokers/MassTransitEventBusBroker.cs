using MassTransit;
using MediatR;
using StudyMate.Application.Common.Events.Brokers;
using StudyMate.Domain.Common.Events;

namespace StudyMate.Infrastructure.Common.EventBus.Brokers;

/// <summary>
/// Implementation of <see cref="IEventBusBroker"/> that utilizes a mass transit for publishing events
/// </summary>
/// <param name="bus">The bus (mass transit) instance to be used for event publication.</param>
/// <param name="mediator">The mediator instance to be used for event local publication.</param>
public class MassTransitEventBusBroker(IBus bus, IPublisher mediator) : IEventBusBroker
{
    public async ValueTask PublishLocalAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : EventBase =>
        await mediator.Publish(@event, cancellationToken);

    public async ValueTask PublishAsync<TEvent>(TEvent @event, EventOptions eventOptions, CancellationToken cancellationToken = default) where TEvent : EventBase =>
        await bus.Publish(@event, cancellationToken);
}