using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.Common.ValueObjects;

public sealed class ReviewId : ValueObject
{
    public Guid Value { get; }

    public ReviewId(Guid value)
    {
        Value = value;
    }

    public static ReviewId ConvertFromString(string value)
    {
        return new(Guid.Parse(value));
    }

    public static ReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}