using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Verify;

public class VerifyEmailProfileCommandValidator : AbstractValidator<VerifyEmailProfileCommand>
{
    public VerifyEmailProfileCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Token format.");
    }
}