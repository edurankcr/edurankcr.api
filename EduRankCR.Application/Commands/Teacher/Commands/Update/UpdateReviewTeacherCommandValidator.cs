using FluentValidation;

namespace EduRankCR.Application.Commands.Teacher.Commands.Update;

public class UpdateReviewTeacherCommandValidator : AbstractValidator<UpdateReviewTeacherCommand>
{
    public UpdateReviewTeacherCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.TeacherId)
            .NotEmpty().WithMessage("TeacherId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TeacherId format.");

        RuleFor(x => x.InstituteId)
            .Must(id => string.IsNullOrEmpty(id) || Guid.TryParse(id, out _))
            .WithMessage("Invalid InstituteId format.");

        RuleFor(x => x.CourseCode)
            .MaximumLength(32).When(x => !string.IsNullOrWhiteSpace(x.CourseCode))
            .Matches(@"^[A-Za-z0-9-_]+$").When(x => !string.IsNullOrWhiteSpace(x.CourseCode))
            .WithMessage("CourseCode can only contain letters, numbers, hyphens (-), and underscores (_). Example: CS101, MATH_200, HIST-300.");

        RuleFor(x => x.CourseMode)
            .InclusiveBetween(0, 3)
            .When(x => x.CourseMode.HasValue)
            .WithMessage("CourseMode must be between 0 and 3 (0 = Online Only, 1 = In-Person Only, 2 = Hybrid).");

        RuleFor(x => x.ProfessorRating)
            .InclusiveBetween(1.0m, 5.0m)
            .When(x => x.ProfessorRating.HasValue)
            .WithMessage("ProfessorRating must be between 1.0 and 5.0.");

        RuleFor(x => x.DifficultyRating)
            .InclusiveBetween(1.0m, 5.0m)
            .When(x => x.DifficultyRating.HasValue)
            .WithMessage("DifficultyRating must be between 1.0 and 5.0.");

        RuleFor(x => x.GradeReceived)
            .MaximumLength(15).When(x => !string.IsNullOrWhiteSpace(x.GradeReceived))
            .Matches(@"^[A-F][+-]?$|^(100|[0-9]{1,2}(\.\d{1,2})?)$|^(Approved|Failed)$")
            .When(x => !string.IsNullOrWhiteSpace(x.GradeReceived))
            .WithMessage("GradeReceived must be a valid letter grade (A-F, A+, B-, etc.), numeric score (0-100), or 'Approved/Failed'.");

        RuleFor(x => x.ExperienceText)
            .MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.ExperienceText))
            .Matches(@"^[\p{L}0-9\s.,!?¡¿()'""-_]+$").When(x => !string.IsNullOrWhiteSpace(x.ExperienceText))
            .WithMessage("ExperienceText contains invalid characters.");
    }
}