using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Domain.Teachers.Projections;

public sealed class TeacherRatingProjection : UserMinimalProjection
{
    public Guid TeacherRatingId { get; init; }
    public Guid TeacherId { get; init; }
    public Guid UserId { get; init; }
    public byte Clarity { get; init; }
    public byte Knowledge { get; init; }
    public byte Respect { get; init; }
    public byte Fairness { get; init; }
    public byte Punctuality { get; init; }
    public byte Motivation { get; init; }
    public bool WouldTakeAgain { get; init; }
    public string Testimony { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public byte Status { get; init; }
}