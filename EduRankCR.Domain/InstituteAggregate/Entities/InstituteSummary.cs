using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;

namespace EduRankCR.Domain.InstituteAggregate.Entities;

public sealed class InstituteSummary : Entity<InstituteId>
{
    public int TotalReviews { get; }
    public decimal TotalAverageScore { get; }
    public decimal Reputation { get; }
    public decimal Opportunities { get; }
    public decimal Happiness { get; }
    public decimal Location { get; }
    public decimal Facilities { get; }
    public decimal Social { get; }
    public decimal Clubs { get; }
    public decimal Internet { get; }
    public decimal Security { get; }
    public decimal Food { get; }
    public DateTime UpdatedAt { get; }

    private InstituteSummary(
        InstituteId instituteId,
        int totalReviews,
        decimal totalAverageScore,
        decimal reputation,
        decimal opportunities,
        decimal happiness,
        decimal location,
        decimal facilities,
        decimal social,
        decimal clubs,
        decimal internet,
        decimal security,
        decimal food,
        DateTime updatedAt)
        : base(instituteId)
    {
        TotalReviews = totalReviews;
        TotalAverageScore = totalAverageScore;
        Reputation = reputation;
        Opportunities = opportunities;
        Happiness = happiness;
        Location = location;
        Facilities = facilities;
        Social = social;
        Clubs = clubs;
        Internet = internet;
        Security = security;
        Food = food;
        UpdatedAt = updatedAt;
    }

    public static InstituteSummary Create(
        InstituteId instituteId,
        int totalReviews,
        decimal totalAverageScore,
        decimal reputation,
        decimal opportunities,
        decimal happiness,
        decimal location,
        decimal facilities,
        decimal social,
        decimal clubs,
        decimal internet,
        decimal security,
        decimal food)
    {
        return new InstituteSummary(
            instituteId,
            totalReviews,
            totalAverageScore,
            reputation,
            opportunities,
            happiness,
            location,
            facilities,
            social,
            clubs,
            internet,
            security,
            food,
            DateTime.UtcNow);
    }

    public static InstituteSummary CreateFromPersistence(
        Guid instituteId,
        int totalReviews,
        decimal totalAverageScore,
        decimal reputation,
        decimal opportunities,
        decimal happiness,
        decimal location,
        decimal facilities,
        decimal social,
        decimal clubs,
        decimal internet,
        decimal security,
        decimal food,
        DateTime updatedAt)
    {
        return new InstituteSummary(
            new InstituteId(instituteId),
            totalReviews,
            totalAverageScore,
            reputation,
            opportunities,
            happiness,
            location,
            facilities,
            social,
            clubs,
            internet,
            security,
            food,
            updatedAt);
    }
}