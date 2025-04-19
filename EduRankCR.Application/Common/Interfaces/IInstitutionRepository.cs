using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRepository
{
    Task<InstitutionProjection?> GetById(Guid institutionId);
}