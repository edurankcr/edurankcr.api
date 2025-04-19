using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Auth.Commands.RequestPasswordReset;

public class RequestPasswordResetCommandValidator : AbstractValidator<RequestPasswordResetCommand>
{
    public RequestPasswordResetCommandValidator()
    {
        RuleFor(x => x.Email)
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