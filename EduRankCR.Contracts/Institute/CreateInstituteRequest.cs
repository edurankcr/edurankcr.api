namespace EduRankCR.Contracts.Institute;

public record CreateInstituteRequest(
    string Name,
    int Type,
    int Province,
    int District,
    string? Url);