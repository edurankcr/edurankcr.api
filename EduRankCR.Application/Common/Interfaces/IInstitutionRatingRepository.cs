using EduRankCR.Domain.Institutions;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRatingRepository
{
    Task<IEnumerable<InstitutionRatingProjection>?> GetByInstitutionId(Guid institutionId);
    Task CreateRating(InstitutionRating rating);
    Task<bool> HasUserAlreadyRated(Guid institutionId, Guid userId);
}