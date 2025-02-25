using FluentValidation;

namespace EduRankCR.Application.Profile.Commands.Email;

public class VerifyChangeEmailCommandValidator : AbstractValidator<VerifyChangeEmailCommand>
{
    public VerifyChangeEmailCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}