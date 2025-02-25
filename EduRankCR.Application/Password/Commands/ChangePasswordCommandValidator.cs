using FluentValidation;

namespace EduRankCR.Application.Password.Commands;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(6).MaximumLength(32);
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6).MaximumLength(32);
    }
}
