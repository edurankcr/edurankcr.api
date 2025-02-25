using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Models;

using MediatR;

namespace EduRankCR.Infrastructure.Persistence;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchEventsAsync<T>(T entity)
        where T : IHasDomainEvent
    {
        var events = entity.DomainEvents.ToList();
        entity.ClearDomainEvents();

        foreach (var domainEvent in events)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}