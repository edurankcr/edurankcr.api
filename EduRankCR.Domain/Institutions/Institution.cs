using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Institutions;

public sealed class Institution
{
    public Guid InstitutionId { get; private set; }
    public Guid? UserId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public Province Province { get; private set; }
    public InstitutionType Type { get; private set; }
    public string? WebsiteUrl { get; private set; }
    public string? AiReviewSummary { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Status Status { get; private set; }

    private Institution() { }

    public static Institution Create(
        Guid institutionId,
        Guid? userId,
        string name,
        string? description,
        Province province,
        InstitutionType type,
        string? websiteUrl,
        string? aiReviewSummary,
        Status status)
    {
        var now = DateTime.UtcNow;

        return new Institution
        {
            InstitutionId = institutionId,
            UserId = userId,
            Name = name,
            Description = description,
            Province = province,
            Type = type,
            WebsiteUrl = websiteUrl,
            AiReviewSummary = aiReviewSummary,
            CreatedAt = now,
            UpdatedAt = now,
            Status = status,
        };
    }
}