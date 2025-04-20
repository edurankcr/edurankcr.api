namespace EduRankCR.Application.Common;

public sealed record UserMinimalResult(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);