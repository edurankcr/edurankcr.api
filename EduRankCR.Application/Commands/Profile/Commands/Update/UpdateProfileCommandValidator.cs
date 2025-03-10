using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Update;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(64);
        RuleFor(x => x.LastName).MaximumLength(96);
        RuleFor(x => x.UserName).MaximumLength(20);
        RuleFor(x => x.BirthDate).LessThanOrEqualTo(DateTime.Now.AddYears(-18)).GreaterThanOrEqualTo(DateTime.Now.AddYears(-100));
        RuleFor(x => x.AvatarUrl).MaximumLength(255);
        RuleFor(x => x.Biography).MaximumLength(512);
    }
}