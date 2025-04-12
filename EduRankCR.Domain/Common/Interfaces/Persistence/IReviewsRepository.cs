using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IReviewsRepository
{
    Task<(List<ReviewTeacherProjection> TeacherReviews, List<ReviewInstituteProjection> InstituteReviews)> GetLastReviews();
}