using EduRankCR.Application.Common;

namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionRatingResult(
    InstitutionRatingInstitutionResult Review,
    UserMinimalResult User);

public sealed record InstitutionRatingInstitutionResult(
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