using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Institutions.Projections;

public sealed class LatestInstitutionRatingProjection : UserRatingProjection
{
    public Guid InstitutionRatingId { get; init; }
    public Guid InstitutionId { get; init; }
    public Guid? UserId { get; init; }
    public byte Location { get; init; }
    public byte Happiness { get; init; }
    public byte Safety { get; init; }
    public byte Reputation { get; init; }
    public byte Opportunities { get; init; }
    public byte Internet { get; init; }
    public byte Food { get; init; }
    public byte Social { get; init; }
    public byte Facilities { get; init; }
    public byte Clubs { get; init; }
    public string Testimony { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public Status Status { get; init; }
}