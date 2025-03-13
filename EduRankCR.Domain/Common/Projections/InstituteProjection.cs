namespace EduRankCR.Domain.Common.Projections;

public record InstituteProjection(
    Guid InstituteId,
    string Name,
    byte Type,
    byte Province,
    short District,
    string? Url);