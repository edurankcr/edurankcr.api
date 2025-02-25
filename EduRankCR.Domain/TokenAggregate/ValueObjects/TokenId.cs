using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.TokenAggregate.ValueObjects;

public sealed class TokenId : ValueObject
{
    public Guid Value { get; }

    public TokenId(Guid value)
    {
        Value = value;
    }

    public static TokenId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}