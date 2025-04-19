using System.Text.RegularExpressions;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Common.Utils;

public static class ValidationHelper
{
    private const long AllowedAvatarSize = 5 * 1024 * 1024;
    private static readonly string[] AllowedEmailDomains = { "gmail.com", "yahoo.com", "hotmail.com", "icloud.com", "outlook.com" };
    private static readonly string[] AllowedAvatarExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };

    public static bool IsValidEmail(string email)
    {
        var emailPattern = @"^[a-zA-Z0-9._%+-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";
        if (!Regex.IsMatch(email, emailPattern))
        {
            return false;
        }

        var domain = email.Split('@').Last().ToLower();
        return AllowedEmailDomains.Contains(domain);
    }

    public static bool IsValidUsername(string username)
    {
        var usernamePattern = @"^(?!.*\.\.)(?!.*__)(?!.*\.$)(?!.*_$)[a-zA-Z0-9._]{1,30}$";
        return Regex.IsMatch(username, usernamePattern);
    }

    public static bool IsValidAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age >= 18 && age <= 100;
    }

    public static bool IsValidAvatar(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLower();

        if (!AllowedAvatarExtensions.Contains(extension))
        {
            return false;
        }

        return file.Length > 0 && file.Length <= AllowedAvatarSize;
    }
}