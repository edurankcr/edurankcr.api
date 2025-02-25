using EduRankCR.Domain.UserAggregate.Enums;

namespace EduRankCR.Contracts.Auth;

public record LoginResponse(
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    DateTime BirthDate,
    UserRole Role,
    UserStatus Status,
    string? AvatarUrl,
    string? Biography,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Token);
