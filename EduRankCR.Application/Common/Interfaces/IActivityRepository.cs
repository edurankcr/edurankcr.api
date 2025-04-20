using EduRankCR.Domain.Institutions.Projections;
using EduRankCR.Domain.Teachers.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IActivityRepository
{
    Task<List<InstitutionRatingProjection>> GetLatestInstitutionReviews();
    Task<List<TeacherRatingProjection>> GetLatestTeacherReviews();
}