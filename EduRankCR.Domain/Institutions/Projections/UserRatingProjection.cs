namespace EduRankCR.Domain.Institutions.Projections;

public class UserRatingProjection
{
    public Guid UserUserId { get; set; }
    public string UserName { get; set; } = null!;
    public string UserLastName { get; set; } = null!;
    public string UserUserName { get; set; } = null!;
    public string UserAvatarUrl { get; set; } = null!;
}