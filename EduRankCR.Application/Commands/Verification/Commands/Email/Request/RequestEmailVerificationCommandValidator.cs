using FluentValidation;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Request;

public class RequestEmailVerificationCommandValidator : AbstractValidator<RequestEmailVerificationCommand>
{
    public RequestEmailVerificationCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
    }
}