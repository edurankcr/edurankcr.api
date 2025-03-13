using EduRankCR.Contracts.Common;

namespace EduRankCR.Contracts.Search;

public record SearchResponse(
    List<TeacherDto> Teachers,
    List<InstituteDto> Institutes);