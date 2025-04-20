namespace EduRankCR.Application.Institutions.Common;

public sealed record GetLatestInstitutionRatingsResult(
    List<LatestInstitutionRating> Ratings);

public sealed record LatestInstitutionRating(
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
    byte Status,
    LatestRatingUser User);

public sealed record LatestRatingUser(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);