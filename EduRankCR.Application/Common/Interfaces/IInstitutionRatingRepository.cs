using EduRankCR.Domain.Institutions;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRatingRepository
{
    Task<IEnumerable<InstitutionRatingProjection>?> GetByInstitutionId(Guid institutionId);
    Task<InstitutionRatingProjection?> GetByInstitutionAndUser(Guid institutionId, Guid userId);
    Task CreateRating(InstitutionRating rating);
    Task<bool> HasUserAlreadyRated(Guid institutionId, Guid userId);
    Task Update(
        Guid institutionRatingId,
        Guid userId,
        int? location,
        int? happiness,
        int? safety,
        int? reputation,
        int? opportunities,
        int? internet,
        int? food,
        int? social,
        int? facilities,
        int? clubs,
        string? testimony);
}