namespace EduRankCR.Contracts.Account;

public sealed record UserResponse(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    string? AvatarUrl,
    string? Biography,
    DateTime BirthDate,
    DateTime? PasswordChangedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt);