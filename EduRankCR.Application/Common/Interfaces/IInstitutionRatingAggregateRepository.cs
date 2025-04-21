using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRatingAggregateRepository
{
    Task<InstitutionRatingAggregateProjection?> GetByInstitutionId(Guid institutionId);
    Task UpsertAggregate(Guid institutionId);
}