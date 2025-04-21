using System.Linq.Expressions;

using FluentValidation;

namespace EduRankCR.Application.Institutions.Commands.UpdateRating;

public class UpdateInstitutionRatingCommandValidator : AbstractValidator<UpdateInstitutionRatingCommand>
{
    public UpdateInstitutionRatingCommandValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.Testimony)
            .MinimumLength(85).WithMessage("Testimony must be at least 85 characters.")
            .MaximumLength(2000).WithMessage("Testimony must be at most 2000 characters.")
            .When(x => x.Testimony is not null);

        AddRatingRule(x => x.Location, nameof(UpdateInstitutionRatingCommand.Location));
        AddRatingRule(x => x.Happiness, nameof(UpdateInstitutionRatingCommand.Happiness));
        AddRatingRule(x => x.Safety, nameof(UpdateInstitutionRatingCommand.Safety));
        AddRatingRule(x => x.Reputation, nameof(UpdateInstitutionRatingCommand.Reputation));
        AddRatingRule(x => x.Opportunities, nameof(UpdateInstitutionRatingCommand.Opportunities));
        AddRatingRule(x => x.Internet, nameof(UpdateInstitutionRatingCommand.Internet));
        AddRatingRule(x => x.Food, nameof(UpdateInstitutionRatingCommand.Food));
        AddRatingRule(x => x.Social, nameof(UpdateInstitutionRatingCommand.Social));
        AddRatingRule(x => x.Facilities, nameof(UpdateInstitutionRatingCommand.Facilities));
        AddRatingRule(x => x.Clubs, nameof(UpdateInstitutionRatingCommand.Clubs));
    }

    private void AddRatingRule(
        Expression<Func<UpdateInstitutionRatingCommand, int?>> selector,
        string propertyName)
    {
        RuleFor(selector)
            .InclusiveBetween(1, 5)
            .WithMessage($"{propertyName} must be between 1 and 5.")
            .When(x => selector.Compile().Invoke(x).HasValue);
    }
}