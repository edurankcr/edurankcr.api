namespace EduRankCR.Domain.Common.Projections;

public record TeacherProjection(
    Guid TeacherId,
    string Name,
    string LastName,
    Guid InstituteId,
    string InstituteName);