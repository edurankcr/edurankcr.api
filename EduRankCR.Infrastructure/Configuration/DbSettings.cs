namespace EduRankCR.Infrastructure.Configuration;

public class DbSettings
{
    public const string SectionName = "DbSettings";
    public string ConnectionString { get; init; } = null!;
}