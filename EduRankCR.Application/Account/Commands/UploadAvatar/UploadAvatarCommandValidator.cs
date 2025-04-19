using EduRankCR.Application.Common.Utils;

using FluentValidation;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Account.Commands.UploadAvatar;

public class UploadAvatarCommandValidator : AbstractValidator<UploadAvatarCommand>
{
    public UploadAvatarCommandValidator()
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("Avatar file is required.")
            .Must(BeValidAvatar).WithMessage("Invalid file format. Only JPG, JPEG, PNG, or WEBP, GIF files are allowed and the file size must be less than 5MB.");
    }

    private static bool BeValidAvatar(IFormFile file)
    {
        return ValidationHelper.IsValidAvatar(file);
    }
}