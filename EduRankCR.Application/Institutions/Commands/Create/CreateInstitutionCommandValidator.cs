using FluentValidation;

namespace EduRankCR.Application.Institutions.Commands.Create;

public sealed class CreateInstitutionCommandValidator : AbstractValidator<CreateInstitutionCommand>
{
    public CreateInstitutionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .Matches(@"^[a-zA-Z0-9\s\.,'""-]+$")
            .WithMessage("Institute name contains invalid characters.");

        RuleFor(x => x.Description)
            .MaximumLength(2000);

        RuleFor(x => x.WebsiteUrl)
            .MaximumLength(255)
            .Matches(@"^https:\/\/([\w\-]+\.)+[\w\-]+(\/[\w\-./?%&=]*)?$")
            .WithMessage("URL must start with 'https://' and be a valid web address.")
            .When(x => x.WebsiteUrl is not null);

        RuleFor(x => x.Province)
            .IsInEnum()
            .WithMessage("Province type must be between 1 and 7 (1 = San José, 2 = Alajuela, 3 = Cartago, 4 = Heredia, 5 = Guanacaste, 6 = Puntarenas, 7 = Limón).");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Institute type must be between 0 and 3 (0 = School, 1 = College, 2 = University, 3 = Institute).");
    }
}