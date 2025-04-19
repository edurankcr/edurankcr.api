using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRatingRepository
{
    Task<IEnumerable<InstitutionRatingProjection>?> GetByInstitutionId(Guid institutionId);
}