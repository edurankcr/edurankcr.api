using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateInstituteCommandValidator : AbstractValidator<CreateInstituteCommand>
{
    public CreateInstituteCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid InstituteId format.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .Matches(@"^[a-zA-Z0-9\s\.,'""-]+$")
            .WithMessage("Institute name contains invalid characters.");

        RuleFor(x => x.Type)
            .NotNull()
            .InclusiveBetween(0, 3)
            .WithMessage("Institute type must be between 0 and 3 (0 = School, 1 = College, 2 = University, 3 = Institute).");

        RuleFor(x => x.Province)
            .NotNull()
            .InclusiveBetween(1, 7)
            .WithMessage("Province type must be between 1 and 7 (1 = San José, 2 = Alajuela, 3 = Cartago, 4 = Heredia, 5 = Guanacaste, 6 = Puntarenas, 7 = Limón).");

        RuleFor(x => x.District)
            .NotNull()
            .InclusiveBetween(101, 706)
            .WithMessage("District type must be between 101 and 706.");

        RuleFor(x => x.Url)
            .NotEmpty()
            .MaximumLength(350)
            .Matches(@"^https:\/\/([\w\-]+\.)+[\w\-]+(\/[\w\-./?%&=]*)?$")
            .WithMessage("URL must start with 'https://' and be a valid web address.");
    }
}