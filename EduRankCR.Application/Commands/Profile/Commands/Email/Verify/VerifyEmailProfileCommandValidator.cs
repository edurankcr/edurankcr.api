using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Verify;

public class VerifyEmailProfileCommandValidator : AbstractValidator<VerifyEmailProfileCommand>
{
    public VerifyEmailProfileCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}