using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.TeacherAggregate.Entities;

public sealed class Teacher : Entity<TeacherId>
{
    public UserId UserId { get; }
    public string Name { get; }
    public string LastName { get; }
    public Status Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Teacher(
        TeacherId teacherId,
        UserId userId,
        string name,
        string lastName,
        Status status,
        DateTime createdAt,
        DateTime updatedAt)
        : base(teacherId)
    {
        UserId = userId;
        Name = name;
        LastName = lastName;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Teacher Create(
        UserId userId,
        string name,
        string lastName,
        Status status)
    {
        var teacher = new Teacher(
            TeacherId.CreateUnique(),
            userId,
            name,
            lastName,
            status,
            DateTime.UtcNow,
            DateTime.UtcNow);

        return teacher;
    }

    public static Teacher CreateFromPersistence(
        Guid teacherId,
        Guid userId,
        string name,
        string lastName,
        byte status,
        DateTime createdAt,
        DateTime updatedAt)
    {
        var teacher = new Teacher(
            new TeacherId(teacherId),
            new UserId(userId),
            name,
            lastName,
            (Status)status,
            createdAt,
            updatedAt);

        return teacher;
    }
}