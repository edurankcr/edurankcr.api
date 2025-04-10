using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.InstituteAggregate.Enums;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.InstituteAggregate.Entities;

public sealed class Institute : Entity<InstituteId>
{
    public UserId UserId { get; }
    public string Name { get; }
    public InstituteType Type { get; }
    public Province Province { get; }
    public string? Url { get; }
    public Status Status { get; }

    private Institute(
        InstituteId instituteId,
        UserId userId,
        string name,
        InstituteType type,
        Province province,
        string? url,
        Status status)
        : base(instituteId)
    {
        UserId = userId;
        Name = name;
        Type = type;
        Province = province;
        Url = url;
        Status = status;
    }

    public static Institute Create(
        UserId userId,
        string name,
        InstituteType type,
        Province province,
        string? url,
        Status status)
    {
        var institute = new Institute(
            InstituteId.CreateUnique(),
            userId,
            name,
            type,
            province,
            url,
            status);

        return institute;
    }

    public static Institute CreateFromPersistence(
        Guid instituteId,
        Guid userId,
        string name,
        byte type,
        byte province,
        string? url,
        byte status)
    {
        var institute = new Institute(
            new InstituteId(instituteId),
            new UserId(userId),
            name,
            (InstituteType)type,
            (Province)province,
            url,
            (Status)status);

        return institute;
    }
}