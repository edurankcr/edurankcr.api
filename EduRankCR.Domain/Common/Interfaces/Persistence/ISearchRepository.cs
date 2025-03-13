using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.Entities;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ISearchRepository
{
    Task<(List<Teacher> Teachers, List<Institute> Institutes)> SearchAll(
        string name,
        string? type,
        string? instituteId,
        int? typeFilter,
        int? province,
        int? district);
}