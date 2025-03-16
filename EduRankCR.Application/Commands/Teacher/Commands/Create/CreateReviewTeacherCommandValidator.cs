using FluentValidation;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public class CreateReviewTeacherCommandValidator : AbstractValidator<CreateReviewTeacherCommand>
{
    public CreateReviewTeacherCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.TeacherId)
            .NotEmpty().WithMessage("TeacherId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TeacherId format.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.FreeCourse)
            .NotNull().WithMessage("FreeCourse must be provided.");

        RuleFor(x => x.CourseCode)
            .MaximumLength(32).When(x => !string.IsNullOrWhiteSpace(x.CourseCode))
            .Matches(@"^[A-Za-z0-9-_]+$").When(x => !string.IsNullOrWhiteSpace(x.CourseCode))
            .WithMessage("CourseCode can only contain letters, numbers, hyphens (-), and underscores (_). Example: CS101, MATH_200, HIST-300.");

        RuleFor(x => x.CourseMode)
            .InclusiveBetween(0, 3)
            .WithMessage("CourseMode must be between 0 and 3 (0 = Online Only, 1 = In-Person Only, 2 = Hybrid).");

        RuleFor(x => x.ProfessorRating)
            .NotNull().WithMessage("ProfessorRating is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("ProfessorRating must be between 1.0 and 5.0.");

        RuleFor(x => x.DifficultyRating)
            .NotNull().WithMessage("DifficultyRating is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("DifficultyRating must be between 1.0 and 5.0.");

        RuleFor(x => x.GradeReceived)
            .MaximumLength(15).When(x => !string.IsNullOrWhiteSpace(x.GradeReceived))
            .Matches(@"^[A-F][+-]?$|^(100|[0-9]{1,2}(\.\d{1,2})?)$|^(Approved|Failed)$")
            .When(x => !string.IsNullOrWhiteSpace(x.GradeReceived))
            .WithMessage("GradeReceived must be a valid letter grade (A-F, A+, B-, etc.), numeric score (0-100), or 'Approved/Failed'.");

        RuleFor(x => x.ExperienceText)
            .NotEmpty().WithMessage("ExperienceText is required.")
            .MaximumLength(500).WithMessage("ExperienceText cannot exceed 500 characters.")
            .Matches(@"^[\p{L}0-9\s.,!?¡¿()'""-_]+$").WithMessage("ExperienceText contains invalid characters.");
    }
}