using EduRankCR.Domain.Common.Models;

namespace EduRankCR.Domain.TeacherAggregate.ValueObjects;

public sealed class TeacherId : ValueObject
{
    public Guid Value { get; }

    public TeacherId(Guid value)
    {
        Value = value;
    }

    public static TeacherId ConvertFromString(string value)
    {
        return new(Guid.Parse(value));
    }

    public static TeacherId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}