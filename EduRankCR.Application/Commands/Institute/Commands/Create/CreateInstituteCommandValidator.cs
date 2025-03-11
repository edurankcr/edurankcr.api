using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateInstituteCommandValidator : AbstractValidator<CreateInstituteCommand>
{
    public CreateInstituteCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Type).NotNull();
        RuleFor(x => x.Province).NotNull();
        RuleFor(x => x.District).NotNull();
        RuleFor(x => x.Url).MaximumLength(350);
    }
}