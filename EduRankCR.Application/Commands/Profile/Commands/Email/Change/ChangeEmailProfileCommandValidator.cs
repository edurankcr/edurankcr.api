using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Change;

public class ChangeEmailProfileCommandValidator : AbstractValidator<ChangeEmailProfileCommand>
{
    public ChangeEmailProfileCommandValidator()
    {
        RuleFor(x => x.NewEmail).NotEmpty().EmailAddress().MaximumLength(256);
    }
}