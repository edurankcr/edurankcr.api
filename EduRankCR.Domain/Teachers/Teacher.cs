using EduRankCR.Domain.Common.Enums;

namespace EduRankCR.Domain.Teachers;

public sealed class Teacher
{
    public Guid TeacherId { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? Biography { get; private set; }
    public string? AvatarUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Status Status { get; private set; }

    private Teacher() { }

    private Teacher(
        Guid teacherId,
        Guid userId,
        string name,
        string lastName,
        string? biography,
        string? avatarUrl,
        DateTime createdAt,
        DateTime updatedAt,
        Status status)
    {
        TeacherId = teacherId;
        UserId = userId;
        Name = name;
        LastName = lastName;
        Biography = biography;
        AvatarUrl = avatarUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
    }

    public static Teacher Create(
        Guid userId,
        string name,
        string lastName,
        string? biography,
        string? avatarUrl,
        Status status)
    {
        var now = DateTime.UtcNow;
        return new Teacher(
            Guid.NewGuid(),
            userId,
            name,
            lastName,
            biography,
            avatarUrl,
            now,
            now,
            status);
    }
}