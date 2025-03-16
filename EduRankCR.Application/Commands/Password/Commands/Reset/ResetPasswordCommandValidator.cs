using FluentValidation;

namespace EduRankCR.Application.Commands.Password.Commands.Reset;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Token format.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);
    }
}