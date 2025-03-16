using System.Linq.Expressions;

using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Update;

public class UpdateReviewInstituteCommandValidator : AbstractValidator<UpdateReviewInstituteCommand>
{
    public UpdateReviewInstituteCommandValidator()
    {
        ValidateGuid(x => x.UserId, "UserId");
        ValidateGuid(x => x.InstituteId, "InstituteId");

        ValidateRating(x => x.Reputation, "Reputation");
        ValidateRating(x => x.Opportunities, "Opportunities");
        ValidateRating(x => x.Happiness, "Happiness");
        ValidateRating(x => x.Location, "Location");
        ValidateRating(x => x.Facilities, "Facilities");
        ValidateRating(x => x.Social, "Social");
        ValidateRating(x => x.Clubs, "Clubs");
        ValidateRating(x => x.Internet, "Internet");
        ValidateRating(x => x.Security, "Security");
        ValidateRating(x => x.Food, "Food");

        RuleFor(x => x.ExperienceText)
            .MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.ExperienceText))
            .WithMessage("ExperienceText cannot exceed 500 characters.");
    }

    private void ValidateGuid(Expression<Func<UpdateReviewInstituteCommand, string>> field, string fieldName)
    {
        RuleFor(field)
            .NotEmpty().WithMessage($"{fieldName} is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage($"Invalid {fieldName} format.");
    }

    private void ValidateRating(Expression<Func<UpdateReviewInstituteCommand, decimal?>> field, string fieldName)
    {
        RuleFor(field)
            .InclusiveBetween(1.0m, 5.0m).When(x => field.Compile().Invoke(x).HasValue)
            .WithMessage($"{fieldName} must be between 1.0 and 5.0.");
    }
}