using FluentValidation;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
            .Matches(@"^[\p{L}]+(?:[\s-][\p{L}]+)*$").WithMessage("Name can only contain letters, spaces, and hyphens.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.")
            .Matches(@"^[\p{L}]+(?:[\s-][\p{L}]+)*$").WithMessage("Last name can only contain letters, spaces, and hyphens.");
    }
}