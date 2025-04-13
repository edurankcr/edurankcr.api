namespace EduRankCR.Contracts.Institute;

public record InstituteSummaryResponse(
    Guid InstituteId,
    int TotalReviews,
    decimal TotalAverageScore,
    decimal Reputation,
    decimal Opportunities,
    decimal Happiness,
    decimal Location,
    decimal Facilities,
    decimal Social,
    decimal Clubs,
    decimal Internet,
    decimal Security,
    decimal Food,
    DateTime UpdatedAt);