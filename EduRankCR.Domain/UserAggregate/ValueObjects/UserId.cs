using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }

    public static UserId ConvertFromString(string value)
    {
        return new(Guid.Parse(value));
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}