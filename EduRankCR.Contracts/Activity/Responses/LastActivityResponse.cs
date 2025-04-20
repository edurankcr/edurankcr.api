using EduRankCR.Contracts.Common;

namespace EduRankCR.Contracts.Activity.Responses;

public sealed record LastActivityResponse(
    List<InstitutionReviewItem> InstitutionReviews,
    List<TeacherReviewItem> TeacherReviews);

public sealed record InstitutionReviewItem(
    Guid InstitutionRatingId,
    string Testimony,
    DateTime CreatedAt,
    UserMinimalResponse User);

public sealed record TeacherReviewItem(
    Guid TeacherRatingId,
    string Testimony,
    DateTime CreatedAt,
    UserMinimalResponse User);