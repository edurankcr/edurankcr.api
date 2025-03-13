namespace EduRankCR.Application.Commands.Search.Common;

public record SearchResult(
    List<Domain.TeacherAggregate.Entities.Teacher> Teachers,
    List<Domain.InstituteAggregate.Entities.Institute> Institutes);