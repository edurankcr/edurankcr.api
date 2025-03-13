namespace EduRankCR.Contracts.Auth;

public record LoginResponse(
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    DateTime BirthDate,
    int Role,
    int Status,
    string? AvatarUrl,
    string? Biography,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Token);