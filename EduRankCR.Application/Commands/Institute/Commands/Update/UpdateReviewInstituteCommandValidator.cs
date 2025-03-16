using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Update;

public class UpdateReviewInstituteCommandValidator : AbstractValidator<UpdateReviewInstituteCommand>
{
    public UpdateReviewInstituteCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.InstituteId)
            .NotEmpty().WithMessage("InstituteId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid InstituteId format.");

        RuleFor(x => x.Reputation)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Reputation must be between 1.0 and 5.0.");

        RuleFor(x => x.Opportunities)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Opportunities must be between 1.0 and 5.0.");

        RuleFor(x => x.Happiness)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Happiness must be between 1.0 and 5.0.");

        RuleFor(x => x.Location)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Location must be between 1.0 and 5.0.");

        RuleFor(x => x.Facilities)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Facilities must be between 1.0 and 5.0.");

        RuleFor(x => x.Social)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Social must be between 1.0 and 5.0.");

        RuleFor(x => x.Clubs)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Clubs must be between 1.0 and 5.0.");

        RuleFor(x => x.Internet)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Internet must be between 1.0 and 5.0.");

        RuleFor(x => x.Security)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Security must be between 1.0 and 5.0.");

        RuleFor(x => x.Food)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("Food must be between 1.0 and 5.0.");

        RuleFor(x => x.ExperienceText)
            .MaximumLength(500).WithMessage("ExperienceText cannot exceed 500 characters.");
    }
}