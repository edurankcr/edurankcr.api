namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record InstitutionRatingAggregateResponse(
    float Location,
    float Happiness,
    float Safety,
    float Reputation,
    float Opportunities,
    float Internet,
    float Food,
    float Social,
    float Facilities,
    float Clubs,
    float OverallAverage,
    int ReviewCount);