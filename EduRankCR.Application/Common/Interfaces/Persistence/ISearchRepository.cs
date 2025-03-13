using EduRankCR.Application.DTOs;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface ISearchRepository
{
    Task<(List<TeacherSummaryDto> Teachers, List<InstituteSummaryDto> Institutes)> SearchAll(
        string name,
        string? type, // teacher, institution or all
        string? instituteId,
        int? typeFilter, // institution type
        int? province,
        int? district);
}