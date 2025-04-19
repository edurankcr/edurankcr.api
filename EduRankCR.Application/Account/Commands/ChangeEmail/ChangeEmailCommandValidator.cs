using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Account.Commands.ChangeEmail;

public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
{
    public ChangeEmailCommandValidator()
    {
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