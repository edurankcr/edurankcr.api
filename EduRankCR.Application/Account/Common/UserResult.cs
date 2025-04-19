using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Application.Account.Common;

public sealed record UserResult(
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
    DateTime? PasswordChangedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt);