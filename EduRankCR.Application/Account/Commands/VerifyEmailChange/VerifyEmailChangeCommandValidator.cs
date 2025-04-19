using FluentValidation;

namespace EduRankCR.Application.Account.Commands.VerifyEmailChange;

public sealed class VerifyEmailChangeCommandValidator : AbstractValidator<VerifyEmailChangeCommand>
{
    public VerifyEmailChangeCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("TokenId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TokenId format.");
    }
}