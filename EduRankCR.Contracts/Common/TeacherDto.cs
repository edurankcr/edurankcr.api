namespace EduRankCR.Contracts.Common;

public record TeacherDto(
    Guid TeacherId,
    string Name,
    string LastName,
    Guid InstituteId,
    string InstituteName);