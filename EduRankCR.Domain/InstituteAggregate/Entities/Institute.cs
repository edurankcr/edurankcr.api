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
    public District District { get; }
    public string? Url { get; }
    public InstituteStatus Status { get; }

    private Institute(
        InstituteId instituteId,
        UserId userId,
        string name,
        InstituteType type,
        Province province,
        District district,
        string? url,
        InstituteStatus status)
        : base(instituteId)
    {
        UserId = userId;
        Name = name;
        Type = type;
        Province = province;
        District = district;
        Url = url;
        Status = status;
    }

    public static Institute Create(
        UserId userId,
        string name,
        InstituteType type,
        Province province,
        District district,
        string? url,
        InstituteStatus status)
    {
        var institute = new Institute(
            InstituteId.CreateUnique(),
            userId,
            name,
            type,
            province,
            district,
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
        int district,
        string? url,
        byte status)
    {
        var institute = new Institute(
            new InstituteId(instituteId),
            new UserId(userId),
            name,
            (InstituteType)type,
            (Province)province,
            (District)district,
            url,
            (InstituteStatus)status);

        return institute;
    }
}