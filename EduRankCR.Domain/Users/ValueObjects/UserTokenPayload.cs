using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Users.ValueObjects;

public sealed record UserTokenPayload(
    Guid UserId,
    string Name,
    string Email,
    Role Role);