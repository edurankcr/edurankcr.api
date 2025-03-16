namespace EduRankCR.Contracts.Institute;

public record UpdateReviewInstituteRequest(
    decimal? Reputation,
    decimal? Opportunities,
    decimal? Happiness,
    decimal? Location,
    decimal? Facilities,
    decimal? Social,
    decimal? Clubs,
    decimal? Internet,
    decimal? Security,
    decimal? Food,
    string? ExperienceText);