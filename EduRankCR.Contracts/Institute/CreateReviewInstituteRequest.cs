namespace EduRankCR.Contracts.Institute;

public record CreateReviewInstituteRequest(
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
    string ExperienceText);