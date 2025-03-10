using FluentValidation;

namespace EduRankCR.Application.Commands.Register.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(96);
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(32);
        RuleFor(x => x.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddYears(-18)).GreaterThanOrEqualTo(DateTime.Now.AddYears(-100));
    }
}