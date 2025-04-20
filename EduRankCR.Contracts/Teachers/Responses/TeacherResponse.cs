namespace EduRankCR.Contracts.Teachers.Responses;

public sealed record TeacherResponse(
    Guid TeacherId,
    string Name,
    string LastName,
    string? Biography,
    string? AvatarUrl,
    DateTime CreatedAt,
    DateTime UpdatedAt);