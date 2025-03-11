using FluentValidation;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.InstituteId).NotNull();
        RuleFor(x => x.UserId).NotNull();
    }
}