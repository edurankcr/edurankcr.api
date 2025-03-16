using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.InstituteAggregate.Entities;

public sealed class InstituteReview : Entity<ReviewId>
{
    public UserId UserId { get; }
    public InstituteId InstituteId { get; }
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
    public string ExperienceText { get; }
    public Status Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private InstituteReview(
        ReviewId reviewId,
        UserId userId,
        InstituteId instituteId,
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
        string experienceText,
        Status status,
        DateTime createdAt,
        DateTime updatedAt)
        : base(reviewId)
    {
        UserId = userId;
        InstituteId = instituteId;
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
        ExperienceText = experienceText;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static InstituteReview Create(
        UserId userId,
        InstituteId instituteId,
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
        string experienceText,
        Status status)
    {
        return new InstituteReview(
            ReviewId.CreateUnique(),
            userId,
            instituteId,
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
            experienceText,
            status,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public static InstituteReview CreateFromPersistence(
        Guid reviewId,
        Guid userId,
        Guid instituteId,
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
        string experienceText,
        byte status,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new InstituteReview(
            new ReviewId(reviewId),
            new UserId(userId),
            new InstituteId(instituteId),
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
            experienceText,
            (Status)status,
            createdAt,
            updatedAt);
    }
}