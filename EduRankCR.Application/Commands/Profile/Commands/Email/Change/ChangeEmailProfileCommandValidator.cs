using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Change;

public class ChangeEmailProfileCommandValidator : AbstractValidator<ChangeEmailProfileCommand>
{
    public ChangeEmailProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.NewEmail)
            .NotEmpty()
            .MaximumLength(256)
            .Must(BeValidEmail)
            .WithMessage("Email must be from a common provider (e.g., Gmail, Yahoo, Hotmail, iCloud).");
    }

    private bool BeValidEmail(string email)
    {
        return ValidationHelper.IsValidEmail(email);
    }
}