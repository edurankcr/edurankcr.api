using FluentValidation;

namespace EduRankCR.Application.Password.Commands;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(255);
    }
}
