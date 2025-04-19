using EduRankCR.Domain.Institutions;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRepository
{
    Task<InstitutionProjection?> GetById(Guid institutionId);
    Task<List<InstitutionRelatedProjection>> GetRelatedByProvince(Guid institutionId);
    Task Create(Institution institution);
    Task<bool> ExistsInReview(Guid userId);
}