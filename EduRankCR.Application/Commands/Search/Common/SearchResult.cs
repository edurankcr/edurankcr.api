using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Application.Commands.Search.Common;

public record SearchResult(
    List<TeacherProjection> Teachers,
    List<InstituteProjection> Institutes);