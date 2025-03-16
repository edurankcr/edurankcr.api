using EduRankCR.Application.Common.Utils;

using FluentValidation;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;

public class ChangeAvatarProfileCommandValidator : AbstractValidator<ChangeAvatarProfileCommand>
{
    public ChangeAvatarProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.Avatar)
            .NotNull().WithMessage("Avatar file is required.")
            .Must(BeValidAvatar).WithMessage("Invalid file format. Only JPG, JPEG, PNG, or WEBP, GIF files are allowed and the file size must be less than 5MB.");
    }

    private static bool BeValidAvatar(IFormFile file)
    {
        return ValidationHelper.IsValidAvatar(file);
    }
}