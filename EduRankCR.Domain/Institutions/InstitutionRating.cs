using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Institutions;

public sealed class InstitutionRating
{
    public Guid InstitutionRatingId { get; private set; }
    public Guid InstitutionId { get; private set; }
    public Guid UserId { get; private set; }

    public int Location { get; private set; }
    public int Happiness { get; private set; }
    public int Safety { get; private set; }
    public int Reputation { get; private set; }
    public int Opportunities { get; private set; }
    public int Internet { get; private set; }
    public int Food { get; private set; }
    public int Social { get; private set; }
    public int Facilities { get; private set; }
    public int Clubs { get; private set; }

    public string Testimony { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Status Status { get; private set; }

    private InstitutionRating() { }

    public static InstitutionRating Create(
        Guid institutionRatingId,
        Guid institutionId,
        Guid userId,
        int location,
        int happiness,
        int safety,
        int reputation,
        int opportunities,
        int internet,
        int food,
        int social,
        int facilities,
        int clubs,
        string testimony,
        Status status)
    {
        var now = DateTime.UtcNow;

        return new InstitutionRating
        {
            InstitutionRatingId = institutionRatingId,
            InstitutionId = institutionId,
            UserId = userId,
            Location = location,
            Happiness = happiness,
            Safety = safety,
            Reputation = reputation,
            Opportunities = opportunities,
            Internet = internet,
            Food = food,
            Social = social,
            Facilities = facilities,
            Clubs = clubs,
            Testimony = testimony,
            CreatedAt = now,
            UpdatedAt = null,
            Status = status,
        };
    }
}