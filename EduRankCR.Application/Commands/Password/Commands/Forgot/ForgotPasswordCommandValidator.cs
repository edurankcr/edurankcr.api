using FluentValidation;

namespace EduRankCR.Application.Commands.Password.Commands.Forgot;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(255);
    }
}