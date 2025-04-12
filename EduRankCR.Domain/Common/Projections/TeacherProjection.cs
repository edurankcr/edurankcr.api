namespace EduRankCR.Domain.Common.Projections;

public record TeacherProjection(
    Guid TeacherId,
    string Name,
    string LastName,
    string FullName,
    DateTime CreatedAt,
    DateTime UpdatedAt);