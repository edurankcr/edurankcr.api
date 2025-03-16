using FluentValidation;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Verify;

public class VerifyEmailVerificationCommandValidator : AbstractValidator<VerifyEmailVerificationCommand>
{
    public VerifyEmailVerificationCommandValidator()
    {
        RuleFor(x => x.TokenId)
            .NotEmpty().WithMessage("TokenId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TokenId format.");
    }
}