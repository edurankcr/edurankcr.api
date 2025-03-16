using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Commands.Auth.Queries.Login;

public class LoginAuthQueryValidator : AbstractValidator<LoginAuthQuery>
{
    public LoginAuthQueryValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .MaximumLength(255)
            .Must(BeValidEmailOrUsername)
            .WithMessage("Identifier must be a valid username or an email from common providers (e.g., Gmail, Yahoo, Hotmail, iCloud).");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);
    }

    private bool BeValidEmailOrUsername(string identifier)
    {
        return ValidationHelper.IsValidEmail(identifier) || ValidationHelper.IsValidUsername(identifier);
    }
}