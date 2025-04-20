namespace EduRankCR.Contracts.Search.Responses;

public sealed record SearchResponse(
    SearchMetaResponse Meta,
    SearchResultsResponse Results);

public sealed record SearchMetaResponse(
    int AllCount,
    int AllInstitutionCount,
    int AllTeacherCount);

public sealed record SearchResultsResponse(
    List<SearchInstitutionResponse> Institutions,
    List<SearchTeacherResponse> Teachers);

public sealed record SearchInstitutionResponse(
    Guid InstitutionId,
    string Name,
    byte Province,
    byte Type,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    float OverallAverage,
    int ReviewCount);

public sealed record SearchTeacherResponse(
    Guid TeacherId,
    string Name,
    string LastName,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    float OverallAverage,
    int ReviewCount);