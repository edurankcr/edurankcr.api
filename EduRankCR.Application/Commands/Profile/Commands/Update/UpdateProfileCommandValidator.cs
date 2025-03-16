using EduRankCR.Application.Common.Utils;

using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Update;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.Name)
            .MaximumLength(64)
            .When(x => x.Name != null)
            .WithMessage("Name cannot exceed 64 characters.");

        RuleFor(x => x.LastName)
            .MaximumLength(96)
            .When(x => x.LastName != null)
            .WithMessage("Last Name cannot exceed 96 characters.");

        RuleFor(x => x.UserName)
            .MinimumLength(3)
            .MaximumLength(20)
            .Must(BeValidUsername)
            .When(x => x.UserName != null)
            .WithMessage("Username must be 3-20 characters and can only contain letters, numbers, underscores, and periods (no consecutive periods or underscores).");

        RuleFor(x => x.BirthDate)
            .Must(x => !x.HasValue || BeValidBirthDate(x.Value))
            .WithMessage("You must be at least 18 years old and under 100 years old.");

        RuleFor(x => x.Biography)
            .MaximumLength(512)
            .When(x => x.Biography != null)
            .WithMessage("Biography cannot exceed 512 characters.");
    }

    private bool BeValidUsername(string username)
    {
        return ValidationHelper.IsValidUsername(username);
    }

    private bool BeValidBirthDate(DateTime birthDate)
    {
        return ValidationHelper.IsValidAge(birthDate);
    }
}