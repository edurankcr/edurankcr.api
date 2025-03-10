using EduRankCR.Application.Commands.Password.Commands.Forgot;

using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateInstituteCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public CreateInstituteCommandValidator()
    {
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(255);
    }
}