namespace EduRankCR.Contracts.Search;

public record SearchRequest(
    string Name,
    string? Type, // teacher, institution or all
    string? InstituteId,
    string? TypeFilter, // institution type
    int? Province,
    int? District);