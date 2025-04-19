using FluentValidation;

namespace EduRankCR.Application.Auth.Commands.ConfirmVerificationEmail;

public class ConfirmVerificationEmailCommandValidator : AbstractValidator<ConfirmVerificationEmailCommand>
{
    public ConfirmVerificationEmailCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("TokenId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TokenId format.");
    }
}