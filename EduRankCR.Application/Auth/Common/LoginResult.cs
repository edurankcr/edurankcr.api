using EduRankCR.Domain.UserAggregate.Entities;

namespace EduRankCR.Application.Auth.Common;

public record LoginResult(User User, string Token);