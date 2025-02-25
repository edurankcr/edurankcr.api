using FluentValidation;

namespace EduRankCR.Application.Auth.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(32);
    }
}