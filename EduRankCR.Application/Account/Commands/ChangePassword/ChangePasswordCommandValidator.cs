using FluentValidation;

namespace EduRankCR.Application.Account.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be empty.");

        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);
    }
}