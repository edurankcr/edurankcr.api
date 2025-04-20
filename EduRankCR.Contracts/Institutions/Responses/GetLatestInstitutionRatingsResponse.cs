namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record GetLatestInstitutionRatingsResponse(
    List<InstitutionRatingItem> Ratings);

public sealed record InstitutionRatingItem(
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
    RatingUser User);

public sealed record RatingUser(
    Guid UserId,
    string Name,
    string LastName,
    string UserName,
    string? AvatarUrl);