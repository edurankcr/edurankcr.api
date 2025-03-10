using FluentValidation;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Verify;

public class VerifyEmailVerificationCommandValidator : AbstractValidator<VerifyEmailVerificationCommand>
{
    public VerifyEmailVerificationCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}