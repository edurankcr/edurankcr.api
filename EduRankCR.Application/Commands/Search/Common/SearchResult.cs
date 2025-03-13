using EduRankCR.Application.DTOs;

namespace EduRankCR.Application.Commands.Search.Common;

public record SearchResult(
    List<TeacherSummaryDto> Teachers,
    List<InstituteSummaryDto> Institutes);