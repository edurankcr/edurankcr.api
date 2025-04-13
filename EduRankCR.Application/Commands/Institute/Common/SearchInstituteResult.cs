using EduRankCR.Domain.InstituteAggregate.Entities;

namespace EduRankCR.Application.Commands.Institute.Common;

public record SearchInstituteResult(
    Domain.InstituteAggregate.Entities.Institute Institute,
    InstituteSummary Summary);