using FluentValidation;

namespace EduRankCR.Application.Commands.Password.Commands.Reset;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Length(6, 32);
    }
}