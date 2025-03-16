using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Queries.Profile;

public class ProfileQueryValidator : AbstractValidator<ProfileQuery>
{
    public ProfileQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");
    }
}