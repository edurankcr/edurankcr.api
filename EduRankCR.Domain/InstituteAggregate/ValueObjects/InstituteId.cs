using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.InstituteAggregate.ValueObjects;

public sealed class InstituteId : ValueObject
{
    public Guid Value { get; }

    public InstituteId(Guid value)
    {
        Value = value;
    }

    public static InstituteId ConvertFromString(string value)
    {
        return new(Guid.Parse(value));
    }

    public static InstituteId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}