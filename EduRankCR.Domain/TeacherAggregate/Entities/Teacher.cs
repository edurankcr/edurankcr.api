using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.TeacherAggregate.Entities;

public sealed class Teacher : Entity<TeacherId>
{
    public UserId UserId { get; }
    public InstituteId InstituteId { get; }
    public string Name { get; }
    public string LastName { get; }
    public TeacherStatus Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Teacher(
        TeacherId teacherId,
        UserId userId,
        InstituteId instituteId,
        string name,
        string lastName,
        TeacherStatus status,
        DateTime createdAt,
        DateTime updatedAt)
        : base(teacherId)
    {
        UserId = userId;
        InstituteId = instituteId;
        Name = name;
        LastName = lastName;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Teacher Create(
        UserId userId,
        InstituteId instituteId,
        string name,
        string lastName,
        TeacherStatus status)
    {
        var teacher = new Teacher(
            TeacherId.CreateUnique(),
            userId,
            instituteId,
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
        Guid instituteId,
        string name,
        string lastName,
        byte status,
        DateTime createdAt,
        DateTime updatedAt)
    {
        var teacher = new Teacher(
            new TeacherId(teacherId),
            new UserId(userId),
            new InstituteId(instituteId),
            name,
            lastName,
            (TeacherStatus)status,
            createdAt,
            updatedAt);

        return teacher;
    }
}