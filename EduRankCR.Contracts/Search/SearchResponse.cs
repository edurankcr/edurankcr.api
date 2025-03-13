namespace EduRankCR.Contracts.Search;

public record SearchResponse(
    List<TeacherSummaryDto> Teachers,
    List<InstituteSummaryDto> Institutes);

public record TeacherSummaryDto(
    Guid TeacherId,
    string Name,
    string LastName,
    Guid InstituteId,
    string InstituteName);

public record InstituteSummaryDto(
    Guid InstituteId,
    string Name,
    int Type,
    int Province,
    int District,
    string? Url);