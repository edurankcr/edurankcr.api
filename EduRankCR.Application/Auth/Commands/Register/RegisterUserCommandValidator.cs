using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Auth.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(96);

        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(20)
            .Must(BeValidUsername)
            .WithMessage("Username must be 3-20 characters and can only contain letters, numbers, underscores, and periods (no consecutive periods or underscores).");

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(255)
            .Must(BeValidEmail)
            .WithMessage("Email must be from a common provider (e.g., Gmail, Yahoo, Hotmail, iCloud).");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(BeValidBirthDate)
            .WithMessage("You must be at least 18 years old and under 100 years old.");
    }

    private bool BeValidUsername(string username)
    {
        return ValidationHelper.IsValidUsername(username);
    }

    private bool BeValidEmail(string email)
    {
        return ValidationHelper.IsValidEmail(email);
    }

    private bool BeValidBirthDate(DateTime birthDate)
    {
        return ValidationHelper.IsValidAge(birthDate);
    }
}