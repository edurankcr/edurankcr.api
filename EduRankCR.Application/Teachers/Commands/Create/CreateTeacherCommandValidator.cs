using FluentValidation;

namespace EduRankCR.Application.Teachers.Commands.Create;

public sealed class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$")
            .WithMessage("Name must contain only letters and spaces.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(200)
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$")
            .WithMessage("Last name must contain only letters and spaces.");

        RuleFor(x => x.Biography)
            .MaximumLength(2000);
    }
}