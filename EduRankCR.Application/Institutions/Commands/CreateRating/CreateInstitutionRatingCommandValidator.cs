using System.Linq.Expressions;

using FluentValidation;

namespace EduRankCR.Application.Institutions.Commands.CreateRating;

public sealed class CreateInstitutionRatingCommandValidator : AbstractValidator<CreateInstitutionRatingCommand>
{
    public CreateInstitutionRatingCommandValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.Testimony)
            .NotEmpty().WithMessage("Testimony is required.")
            .MinimumLength(85).WithMessage("Testimony must be at least 85 characters.")
            .MaximumLength(2000).WithMessage("Testimony must be at most 2000 characters.");

        AddRatingRule(x => x.Location, nameof(CreateInstitutionRatingCommand.Location));
        AddRatingRule(x => x.Happiness, nameof(CreateInstitutionRatingCommand.Happiness));
        AddRatingRule(x => x.Safety, nameof(CreateInstitutionRatingCommand.Safety));
        AddRatingRule(x => x.Reputation, nameof(CreateInstitutionRatingCommand.Reputation));
        AddRatingRule(x => x.Opportunities, nameof(CreateInstitutionRatingCommand.Opportunities));
        AddRatingRule(x => x.Internet, nameof(CreateInstitutionRatingCommand.Internet));
        AddRatingRule(x => x.Food, nameof(CreateInstitutionRatingCommand.Food));
        AddRatingRule(x => x.Social, nameof(CreateInstitutionRatingCommand.Social));
        AddRatingRule(x => x.Facilities, nameof(CreateInstitutionRatingCommand.Facilities));
        AddRatingRule(x => x.Clubs, nameof(CreateInstitutionRatingCommand.Clubs));
    }

    private void AddRatingRule(
        Expression<Func<CreateInstitutionRatingCommand, int>> selector,
        string propertyName)
    {
        RuleFor(selector)
            .NotEmpty()
            .WithMessage($"{propertyName} is required.")
            .InclusiveBetween(1, 5)
            .WithMessage($"{propertyName} must be between 1 and 5.");
    }
}