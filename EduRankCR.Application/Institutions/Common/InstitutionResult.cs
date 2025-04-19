namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionResult(
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