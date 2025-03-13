using EduRankCR.Domain.UserAggregate.Entities;

namespace EduRankCR.Domain.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}