namespace EduRankCR.Application.Common.Interfaces.Services;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string templateName, Dictionary<string, string> placeholders);
}