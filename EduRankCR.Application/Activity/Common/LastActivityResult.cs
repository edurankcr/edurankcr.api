using EduRankCR.Application.Common;

namespace EduRankCR.Application.Activity.Common;

public sealed record LastActivityResult(
    List<InstitutionActivityItem> InstitutionReviews,
    List<TeacherActivityItem> TeacherReviews);

public sealed record InstitutionActivityItem(
    Guid InstitutionRatingId,
    string Testimony,
    DateTime CreatedAt,
    UserMinimalResult User);

public sealed record TeacherActivityItem(
    Guid TeacherRatingId,
    string Testimony,
    DateTime CreatedAt,
    UserMinimalResult User);