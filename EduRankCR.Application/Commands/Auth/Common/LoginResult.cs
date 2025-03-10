using EduRankCR.Domain.UserAggregate.Entities;

namespace EduRankCR.Application.Commands.Auth.Common;

public record LoginResult(User User, string Token);