using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Application.Auth.Common;

public sealed record AuthResult(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string Email,
    bool EmailConfirmed,
    string? NewEmail,
    Role Role,
    Status Status,
    string? AvatarUrl,
    string? Biography,
    DateTime BirthDate,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Token);