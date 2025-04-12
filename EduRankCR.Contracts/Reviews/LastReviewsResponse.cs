using EduRankCR.Contracts.Common;

namespace EduRankCR.Contracts.Reviews;

public record LastReviewsResponse(
    MetaDto Meta,
    LastReviewsContentDto Result);

public record LastReviewsContentDto(
    List<ReviewTeacherDto> TeacherReviews,
    List<ReviewInstituteDto> InstituteReviews);