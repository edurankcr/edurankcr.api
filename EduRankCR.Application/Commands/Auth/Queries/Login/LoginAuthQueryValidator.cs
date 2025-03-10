using FluentValidation;

namespace EduRankCR.Application.Commands.Auth.Queries.Login;

public class LoginAuthQueryValidator : AbstractValidator<LoginAuthQuery>
{
    public LoginAuthQueryValidator()
    {
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(32);
    }
}