namespace EduRankCR.Infrastructure.Configuration;

public class EmailSettings
{
    public const string SectionName = "EmailSettings";
    public string SmtpServer { get; init; } = null!;
    public int SmtpPort { get; init; } = 587;
    public string SenderEmail { get; init; } = null!;
    public string SenderName { get; init; } = null!;
    public string Password { get; init; } = null!;
}