using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Infrastructure.Configuration;
using MailKit.Net.Smtp;

using Microsoft.Extensions.Options;

using MimeKit;

namespace EduRankCR.Infrastructure.Service;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly string _templateDirectory;

    public EmailService(IOptions<EmailSettings> emailOptions)
    {
        var settings = emailOptions.Value;

        _emailSettings = new EmailSettings
        {
            SmtpServer = Environment.GetEnvironmentVariable("email-smtp-server") ?? settings.SmtpServer,
            SmtpPort = int.TryParse(Environment.GetEnvironmentVariable("email-smtp-port"), out var port) ? port : settings.SmtpPort,
            Password = Environment.GetEnvironmentVariable("email-password") ?? settings.Password,
            SenderName = Environment.GetEnvironmentVariable("email-sender-name") ?? settings.SenderName,
            SenderEmail = Environment.GetEnvironmentVariable("email-sender-email") ?? settings.SenderEmail,
        };

        _templateDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
    }

    public async Task SendEmailAsync(string toEmail, string subject, string templateName, Dictionary<string, string> placeholders)
    {
        string templatePath = Path.Combine(_templateDirectory, templateName);
        string htmlBody = LoadHtmlTemplate(templatePath, placeholders);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress(toEmail, toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = htmlBody };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
            await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    private string LoadHtmlTemplate(string templatePath, Dictionary<string, string> placeholders)
    {
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Missing email template: {templatePath}");
        }

        string htmlBody = File.ReadAllText(templatePath);

        foreach (var placeholder in placeholders)
        {
            htmlBody = htmlBody.Replace(placeholder.Key, placeholder.Value);
        }

        return htmlBody;
    }
}