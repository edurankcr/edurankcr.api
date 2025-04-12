namespace EduRankCR.Contracts.Common;

public record TeacherDto(
    Guid TeacherId,
    string Name,
    string LastName,
    string FullName,
    DateTime CreatedAt,
    DateTime UpdatedAt);