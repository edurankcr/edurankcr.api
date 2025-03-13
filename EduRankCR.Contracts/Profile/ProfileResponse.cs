namespace EduRankCR.Contracts.Profile;

public record ProfileResponse(
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    DateTime BirthDate,
    string Role,
    string Status,
    string? AvatarUrl,
    string? Biography,
    DateTime CreatedAt,
    DateTime UpdatedAt);