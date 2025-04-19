namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionRelatedResult(
    Guid InstitutionId,
    string Name,
    string? Description,
    byte Province,
    byte Type,
    string? WebsiteUrl,
    float OverallAverage,
    int ReviewCount);