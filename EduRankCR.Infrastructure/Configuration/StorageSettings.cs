namespace EduRankCR.Infrastructure.Configuration;

public class StorageSettings
{
    public const string SectionName = "StorageSettings";
    public string ConnectionString { get; init; } = null!;
    public string AvatarContainer { get; init; } = null!;
}