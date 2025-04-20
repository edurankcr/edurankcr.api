namespace EduRankCR.Contracts.Common;

public record UserMinimalResponse(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);