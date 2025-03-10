using EduRankCR.Domain.UserAggregate.Events;

using MediatR;

namespace EduRankCR.Application.Register.Event;

public class DummyHandler : INotificationHandler<UserCreated>
{
    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}