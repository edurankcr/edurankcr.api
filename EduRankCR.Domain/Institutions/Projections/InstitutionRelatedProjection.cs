namespace EduRankCR.Domain.Institutions.Projections;

public sealed class InstitutionRelatedProjection
{
    public Guid InstitutionId { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public byte Province { get; init; }
    public byte Type { get; init; }
    public string? WebsiteUrl { get; init; }
    public float OverallAverage { get; init; }
    public int ReviewCount { get; init; }
}