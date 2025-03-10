using FluentValidation;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;

public class ChangeAvatarProfileCommandValidator : AbstractValidator<ChangeAvatarProfileCommand>
{
    private static readonly HashSet<string> AllowedMimeTypes = new()
    {
        "image/jpeg",
        "image/png",
        "image/gif",
        "image/webp",
    };

    public ChangeAvatarProfileCommandValidator()
    {
        RuleFor(x => x.Avatar)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Must(x => x.Length > 0)
            .Must(x => x.Length < 1_048_576)
            .Must(IsValidMimeType);
    }

    private bool IsValidMimeType(IFormFile? file)
    {
        try
        {
            return file != null && AllowedMimeTypes.Contains(file.ContentType.ToLower());
        }
        catch
        {
            return false;
        }
    }
}