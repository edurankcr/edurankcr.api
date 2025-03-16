using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Commands.Password.Commands.Forgot;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .MaximumLength(255)
            .Must(BeValidEmailOrUsername)
            .WithMessage("Identifier must be a valid username or an email from common providers (e.g., Gmail, Yahoo, Hotmail, iCloud).");
    }

    private bool BeValidEmailOrUsername(string identifier)
    {
        return ValidationHelper.IsValidEmail(identifier) || ValidationHelper.IsValidUsername(identifier);
    }
}