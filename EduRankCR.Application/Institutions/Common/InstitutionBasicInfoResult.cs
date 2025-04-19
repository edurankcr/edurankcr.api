namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionBasicInfoResult(
    Guid InstitutionId,
    string Name,
    string? Description,
    byte Province,
    string Type,
    string? WebsiteUrl,
    string? AiReviewSummary,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    byte Status);