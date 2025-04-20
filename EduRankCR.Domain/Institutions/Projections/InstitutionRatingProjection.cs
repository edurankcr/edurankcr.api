using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Domain.Institutions.Projections;

public sealed class InstitutionRatingProjection : UserMinimalProjection
{
    public Guid InstitutionRatingId { get; set; }
    public Guid InstitutionId { get; set; }
    public Guid? UserId { get; set; }
    public byte Location { get; set; }
    public byte Happiness { get; set; }
    public byte Safety { get; set; }
    public byte Reputation { get; set; }
    public byte Opportunities { get; set; }
    public byte Internet { get; set; }
    public byte Food { get; set; }
    public byte Social { get; set; }
    public byte Facilities { get; set; }
    public byte Clubs { get; set; }
    public string Testimony { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
}