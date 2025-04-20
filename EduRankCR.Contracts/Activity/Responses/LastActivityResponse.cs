using EduRankCR.Contracts.Common;

namespace EduRankCR.Contracts.Activity.Responses;

public sealed record LastActivityResponse(
    List<InstitutionReviewItem> InstitutionReviews,
    List<TeacherReviewItem> TeacherReviews);

public sealed record InstitutionReviewItem(
    Guid InstitutionRatingId,
    Guid InstitutionId,
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
    UserMinimalResponse User);

public sealed record TeacherReviewItem(
    Guid TeacherRatingId,
    Guid TeacherId,
    byte Clarity,
    byte Knowledge,
    byte Respect,
    byte Fairness,
    byte Punctuality,
    byte Motivation,
    bool WouldTakeAgain,
    string Testimony,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    UserMinimalResponse User);