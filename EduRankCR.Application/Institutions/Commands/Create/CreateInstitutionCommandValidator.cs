using FluentValidation;

namespace EduRankCR.Application.Institutions.Commands.Create;

public sealed class CreateInstitutionCommandValidator : AbstractValidator<CreateInstitutionCommand>
{
    public CreateInstitutionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Description)
            .MaximumLength(2000);

        RuleFor(x => x.WebsiteUrl)
            .MaximumLength(255)
            .When(x => x.WebsiteUrl is not null);

        RuleFor(x => x.Province)
            .IsInEnum();

        RuleFor(x => x.Type)
            .IsInEnum();
    }
}