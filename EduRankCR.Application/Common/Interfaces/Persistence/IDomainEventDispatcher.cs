using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync<T>(T entity)
        where T : IHasDomainEvent;
}