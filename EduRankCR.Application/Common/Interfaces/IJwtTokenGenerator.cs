using EduRankCR.Domain.Users.ValueObjects;

namespace EduRankCR.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserTokenPayload payload);
}