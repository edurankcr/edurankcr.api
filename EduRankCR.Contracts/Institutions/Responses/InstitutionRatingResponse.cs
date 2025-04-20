using EduRankCR.Contracts.Common;

namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record InstitutionRatingResponse(
    InstitutionRatingInstitutionResponse Review,
    UserMinimalResponse User);

public sealed record InstitutionRatingInstitutionResponse(
    Guid InstitutionRatingId,
    Guid InstitutionId,
    Guid? UserId,
    byte Location,
    byte Happiness,
    byte Safety,
    byte Reputation,
    byte Opportunities,
    byte Internet,
    byte Food,
    byte Social,
    byte Facilities,
    byte Clubs,
    string Testimony,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    byte Status);