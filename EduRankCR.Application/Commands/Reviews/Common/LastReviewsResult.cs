using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Application.Commands.Reviews.Common;

public record LastReviewsResult(
    MetaProjection Meta,
    LastReviewsContent Result);

public record LastReviewsContent(
    List<ReviewTeacherProjection> TeacherReviews,
    List<ReviewInstituteProjection> InstituteReviews);