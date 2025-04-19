namespace EduRankCR.Contracts.Auth.Responses;

public sealed record AuthResponse(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string Email,
    string? NewEmail,
    string? AvatarUrl,
    string? Biography,
    DateTime BirthDate,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Token);