namespace EduRankCR.Contracts.Institutions.Requests;

public sealed record CreateInstitutionRatingRequest(
    Guid InstitutionId,
    int Location,
    int Happiness,
    int Safety,
    int Reputation,
    int Opportunities,
    int Internet,
    int Food,
    int Social,
    int Facilities,
    int Clubs,
    string Testimony);