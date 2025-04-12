using EduRankCR.Domain.Common.Projections;
using EduRankCR.Domain.InstituteAggregate.Entities;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ISearchRepository
{
    Task<(List<TeacherProjection> Teachers, List<InstituteProjection> Institutes)> SearchAll(
        string name,
        string? type,
        string? instituteId,
        int? typeFilter,
        int? province);
}