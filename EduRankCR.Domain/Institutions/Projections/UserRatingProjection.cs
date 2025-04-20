namespace EduRankCR.Domain.Institutions.Projections;

public class UserRatingProjection
{
    public Guid UserUserId { get; init; }
    public string UserName { get; init; } = null!;
    public string UserLastName { get; init; } = null!;
    public string UserUserName { get; init; } = null!;
    public string? UserAvatarUrl { get; init; }
}