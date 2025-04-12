namespace EduRankCR.Contracts.Common;

public record UserInfoDto(
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);