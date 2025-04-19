namespace EduRankCR.Domain.Institutions.Projections;

public sealed class InstitutionRatingAggregateProjection
{
    public Guid InstitutionId { get; set; }
    public float Location { get; set; }
    public float Happiness { get; set; }
    public float Safety { get; set; }
    public float Reputation { get; set; }
    public float Opportunities { get; set; }
    public float Internet { get; set; }
    public float Food { get; set; }
    public float Social { get; set; }
    public float Facilities { get; set; }
    public float Clubs { get; set; }
    public float OverallAverage { get; set; }
    public int ReviewCount { get; set; }
}