using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Auth.Commands.SendVerificationEmail;

public class SendVerificationEmailCommandValidator : AbstractValidator<SendVerificationEmailCommand>
{
    public SendVerificationEmailCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(255)
            .Must(BeValidEmail)
            .WithMessage("Email must be from a common provider (e.g., Gmail, Yahoo, Hotmail, iCloud).");
    }

    private bool BeValidEmail(string email)
    {
        return ValidationHelper.IsValidEmail(email);
    }
}