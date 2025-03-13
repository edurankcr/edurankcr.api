using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync<T>(T entity)
        where T : IHasDomainEvent;
}