using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateReviewInstituteCommandValidator : AbstractValidator<CreateReviewInstituteCommand>
{
    public CreateReviewInstituteCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.InstituteId)
            .NotEmpty().WithMessage("InstituteId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid InstituteId format.");

        RuleFor(x => x.Reputation)
            .NotNull().WithMessage("Reputation is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Reputation must be between 1.0 and 5.0.");

        RuleFor(x => x.Opportunities)
            .NotNull().WithMessage("Opportunities is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Opportunities must be between 1.0 and 5.0.");

        RuleFor(x => x.Happiness)
            .NotNull().WithMessage("Happiness is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Happiness must be between 1.0 and 5.0.");

        RuleFor(x => x.Location)
            .NotNull().WithMessage("Location is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Location must be between 1.0 and 5.0.");

        RuleFor(x => x.Facilities)
            .NotNull().WithMessage("Facilities is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Facilities must be between 1.0 and 5.0.");

        RuleFor(x => x.Social)
            .NotNull().WithMessage("Social is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Social must be between 1.0 and 5.0.");

        RuleFor(x => x.Clubs)
            .NotNull().WithMessage("Clubs is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Clubs must be between 1.0 and 5.0.");

        RuleFor(x => x.Internet)
            .NotNull().WithMessage("Internet is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Internet must be between 1.0 and 5.0.");

        RuleFor(x => x.Security)
            .NotNull().WithMessage("Security is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Security must be between 1.0 and 5.0.");

        RuleFor(x => x.Food)
            .NotNull().WithMessage("Food is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("Food must be between 1.0 and 5.0.");

        RuleFor(x => x.ExperienceText)
            .NotEmpty().WithMessage("ExperienceText is required.")
            .MaximumLength(500).WithMessage("ExperienceText cannot exceed 500 characters.");
    }
}