using FluentValidation;

namespace EduRankCR.Application.Verification.Commands.EmailVerification;

public class VerifyEmailVerificationCommandValidator : AbstractValidator<VerifyEmailVerificationCommand>
{
    public VerifyEmailVerificationCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}
