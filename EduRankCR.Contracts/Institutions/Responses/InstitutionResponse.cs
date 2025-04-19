namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record InstitutionResponse(
    Guid InstitutionId,
    string Name,
    string? Description,
    byte Province,
    byte Type,
    string? WebsiteUrl,
    string? AiReviewSummary,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    byte Status);