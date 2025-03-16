using FluentValidation;

namespace EduRankCR.Application.Commands.Teacher.Commands.Update;

public class UpdateReviewTeacherCommandValidator : AbstractValidator<UpdateReviewTeacherCommand>
{
    public UpdateReviewTeacherCommandValidator()
    {
        RuleFor(x => x.UserId)
            .Must(id => string.IsNullOrEmpty(id) || Guid.TryParse(id, out _))
            .WithMessage("Invalid UserId format.");

        RuleFor(x => x.TeacherId)
            .Must(id => string.IsNullOrEmpty(id) || Guid.TryParse(id, out _))
            .WithMessage("Invalid TeacherId format.");

        RuleFor(x => x.FreeCourse)
            .Must(x => x == null || x is bool)
            .WithMessage("FreeCourse must be a boolean value.");

        RuleFor(x => x.CourseCode)
            .MaximumLength(20).WithMessage("CourseCode cannot exceed 20 characters.");

        RuleFor(x => x.CourseMode)
            .Must(x => x == null || (x >= 0 && x <= 3))
            .WithMessage("CourseMode must be between 0 and 3 (0 = Presencial, 1 = Online, 2 = Híbrido, 3 = Otro).");

        RuleFor(x => x.ProfessorRating)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("ProfessorRating must be between 1.0 and 5.0.");

        RuleFor(x => x.DifficultyRating)
            .Must(x => x == null || (x >= 1.0m && x <= 5.0m))
            .WithMessage("DifficultyRating must be between 1.0 and 5.0.");

        RuleFor(x => x.WouldTakeAgain)
            .Must(x => x == null || x is bool)
            .WithMessage("WouldTakeAgain must be a boolean value.");

        RuleFor(x => x.MandatoryAttendance)
            .Must(x => x == null || x is bool)
            .WithMessage("MandatoryAttendance must be a boolean value.");

        RuleFor(x => x.GradeReceived)
            .MaximumLength(10).WithMessage("GradeReceived cannot exceed 10 characters.");

        RuleFor(x => x.ExperienceText)
            .MaximumLength(500).WithMessage("ExperienceText cannot exceed 500 characters.");
    }
}