namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record InstitutionRelatedResponse(
    Guid InstitutionId,
    string Name,
    string? Description,
    byte Province,
    byte Type,
    string? WebsiteUrl,
    float OverallAverage,
    int ReviewCount);