namespace EduRankCR.Contracts.Institute;

public record InstituteResponse(
    Guid InstituteId,
    string Name,
    byte Type,
    byte Province,
    string? Url,
    byte Status);