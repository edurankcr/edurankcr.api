namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionRatingAggregateResult(
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