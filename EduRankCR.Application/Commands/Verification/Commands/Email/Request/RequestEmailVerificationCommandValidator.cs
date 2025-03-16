using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Request;

public class RequestEmailVerificationCommandValidator : AbstractValidator<RequestEmailVerificationCommand>
{
    public RequestEmailVerificationCommandValidator()
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