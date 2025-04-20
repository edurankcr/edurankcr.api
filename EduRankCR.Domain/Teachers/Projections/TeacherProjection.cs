using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Teachers.Projections;

public sealed class TeacherProjection
{
    public Guid TeacherId { get; init; }
    public string Name { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string? Biography { get; init; }
    public string? AvatarUrl { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public Status Status { get; init; }
}