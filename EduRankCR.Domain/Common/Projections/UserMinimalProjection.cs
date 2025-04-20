namespace EduRankCR.Domain.Common.Projections;

public class UserMinimalProjection
{
    public Guid UserUserId { get; init; }
    public string UserName { get; init; } = null!;
    public string UserLastName { get; init; } = null!;
    public string UserUserName { get; init; } = null!;
    public string? UserAvatarUrl { get; init; }
}