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
            .IsInEnum()
            .WithMessage("Invalid institute type.");

        RuleFor(x => x.Province)
            .NotNull()
            .IsInEnum()
            .WithMessage("Invalid province.");

        RuleFor(x => x.District)
            .NotNull()
            .IsInEnum()
            .WithMessage("Invalid district.");

        RuleFor(x => x.Url)
            .NotEmpty()
            .MaximumLength(350)
            .Matches(@"^https:\/\/([\w\-]+\.)+[\w\-]+(\/[\w\-./?%&=]*)?$")
            .WithMessage("URL must start with 'https://' and be a valid web address.");
    }
}