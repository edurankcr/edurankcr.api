using FluentValidation;

namespace EduRankCR.Application.Profile.Commands.Email;

public class ChangeProfileCommandValidator : AbstractValidator<ChangeEmailCommand>
{
    public ChangeProfileCommandValidator()
    {
        RuleFor(x => x.NewEmail).NotEmpty().EmailAddress().MaximumLength(256);
    }
}