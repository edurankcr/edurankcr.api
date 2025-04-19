using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Institutions.Projections;

public sealed class InstitutionProjection
{
    public Guid InstitutionId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public byte Province { get; set; }
    public InstitutionType Type { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? AiReviewSummary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
}