using EduRankCR.Domain.UserAggregate.Entities;

namespace EduRankCR.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}