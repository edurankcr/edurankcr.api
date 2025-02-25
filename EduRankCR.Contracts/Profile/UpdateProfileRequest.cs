namespace EduRankCR.Contracts.Profile;

public record UpdateProfileRequest(
    string? Name,
    string? LastName,
    string? UserName,
    DateTime? BirthDate,
    string? AvatarUrl,
    string? Biography);