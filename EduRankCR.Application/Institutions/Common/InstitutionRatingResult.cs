namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionRatingResult(
    InstitutionRatingInstitutionResult Institute,
    InstitutionRatingUserResult User);

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

public sealed record InstitutionRatingUserResult(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);