using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.UserAggregate.Entities;

namespace EduRankCR.Domain.UserAggregate.Events;

public record UserCreated(User User) : IDomainEvent;