namespace EduRankCR.Domain.Common.Projections;

public record ReviewUserInfo(
    string UserFirstName,
    string UserLastName,
    string UserName,
    string? AvatarUrl);