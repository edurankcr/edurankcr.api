using FluentValidation;

namespace EduRankCR.Application.Verification.Commands.EmailVerification;

public class RequestEmailVerificationCommandValidator : AbstractValidator<RequestEmailVerificationCommand>
{
    public RequestEmailVerificationCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
    }
}
