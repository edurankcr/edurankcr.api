namespace EduRankCR.Contracts.Common;

public record InstituteDto(
    Guid InstituteId,
    string Name,
    byte Type,
    byte Province,
    string? Url,
    DateTime CreatedAt,
    DateTime UpdatedAt);