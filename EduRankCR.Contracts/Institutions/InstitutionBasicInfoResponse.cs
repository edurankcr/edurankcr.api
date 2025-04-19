namespace EduRankCR.Contracts.Institutions;

public sealed record InstitutionBasicInfoResponse(
    Guid InstitutionId,
    string Name,
    string Description,
    byte Province,
    string Type,
    string? WebsiteUrl,
    string AiReviewSummary,
    DateTime UpdatedAt,
    byte Status);