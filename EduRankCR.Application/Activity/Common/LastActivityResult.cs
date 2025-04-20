using EduRankCR.Application.Common;

namespace EduRankCR.Application.Activity.Common;

public sealed record LastActivityResult(
    List<InstitutionActivityItem> InstitutionReviews,
    List<TeacherActivityItem> TeacherReviews);

public sealed record InstitutionActivityItem(
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
    UserMinimalResult User);

public sealed record TeacherActivityItem(
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
    UserMinimalResult User);