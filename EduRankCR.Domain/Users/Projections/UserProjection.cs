using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Users.Projections;

public sealed class UserProjection
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public bool EmailConfirmed { get; init; }
    public string? NewEmail { get; init; }
    public Role Role { get; init; }
    public Status Status { get; init; }
    public string? AvatarUrl { get; init; }
    public string? Biography { get; init; }
    public DateTime BirthDate { get; init; }
    public DateTime? PasswordChangedAt { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}