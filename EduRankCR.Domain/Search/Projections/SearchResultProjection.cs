namespace EduRankCR.Domain.Search.Projections;

public sealed class SearchResultProjection
{
    public string Type { get; init; } = null!;
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? LastName { get; init; }
    public byte? Province { get; init; }
    public byte? InstitutionType { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public float OverallAverage { get; init; }
    public int ReviewCount { get; init; }
}