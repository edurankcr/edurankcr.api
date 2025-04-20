namespace EduRankCR.Application.Teachers.Common;

public sealed record TeacherResult(
    Guid TeacherId,
    string Name,
    string LastName,
    string? Biography,
    string? AvatarUrl,
    DateTime CreatedAt,
    DateTime UpdatedAt);