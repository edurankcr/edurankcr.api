namespace EduRankCR.Contracts.Auth;

public record LoginResponse(
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    DateTime BirthDate,
    string? AvatarUrl,
    string? Biography,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Token);