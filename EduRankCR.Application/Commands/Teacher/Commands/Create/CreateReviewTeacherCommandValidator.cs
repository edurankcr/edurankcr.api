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

        RuleFor(x => x.FreeCourse)
            .NotNull().WithMessage("FreeCourse must be provided.");

        RuleFor(x => x.CourseCode)
            .MaximumLength(20).WithMessage("CourseCode cannot exceed 20 characters.");

        RuleFor(x => x.CourseMode)
            .InclusiveBetween(0, 3).WithMessage("CourseMode must be between 0 and 3 (0 = Presencial, 1 = Online, 2 = Híbrido, 3 = Otro).");

        RuleFor(x => x.ProfessorRating)
            .NotNull().WithMessage("ProfessorRating is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("ProfessorRating must be between 1.0 and 5.0.");

        RuleFor(x => x.DifficultyRating)
            .NotNull().WithMessage("DifficultyRating is required.")
            .InclusiveBetween(1.0m, 5.0m).WithMessage("DifficultyRating must be between 1.0 and 5.0.");

        RuleFor(x => x.WouldTakeAgain)
            .Must(x => x == null || x is bool).WithMessage("WouldTakeAgain must be a boolean value.");

        RuleFor(x => x.MandatoryAttendance)
            .Must(x => x == null || x is bool).WithMessage("MandatoryAttendance must be a boolean value.");

        RuleFor(x => x.GradeReceived)
            .MaximumLength(10).WithMessage("GradeReceived cannot exceed 10 characters.");

        RuleFor(x => x.ExperienceText)
            .NotEmpty().WithMessage("ExperienceText is required.")
            .MaximumLength(500).WithMessage("ExperienceText cannot exceed 500 characters.");
    }
}