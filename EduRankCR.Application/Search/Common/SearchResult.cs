namespace EduRankCR.Application.Search.Common;

public sealed record SearchResult(
    SearchMeta Meta,
    List<SearchInstitutionItem> Institutions,
    List<SearchTeacherItem> Teachers);

public sealed record SearchMeta(
    int AllCount,
    int AllInstitutionCount,
    int AllTeacherCount);

public sealed record SearchInstitutionItem(
    Guid InstitutionId,
    string Name,
    byte Province,
    byte Type,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    float OverallAverage,
    int ReviewCount);

public sealed record SearchTeacherItem(
    Guid TeacherId,
    string Name,
    string LastName,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    float OverallAverage,
    int ReviewCount);