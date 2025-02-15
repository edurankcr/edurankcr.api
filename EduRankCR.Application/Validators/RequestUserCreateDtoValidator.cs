using FluentValidation;
using EduRankCR.Application.DTOs;

public class RequestUserCreateDtoValidator : AbstractValidator<RequestUserCreateDto>
{
    public RequestUserCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("USERNAME_REQUIRED")
            .MaximumLength(32).WithMessage("USERNAME_LENGTH_INVALID");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LASTNAME_REQUIRED")
            .MaximumLength(64).WithMessage("LASTNAME_LENGTH_INVALID");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("USERNAME_REQUIRED")
            .Matches(@"^[a-zA-Z0-9._]+$").WithMessage("USERNAME_PATTERN_INVALID")
            .MaximumLength(18).WithMessage("USERNAME_LENGTH_INVALID");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("EMAIL_REQUIRED")
            .EmailAddress().WithMessage("EMAIL_PATTERN_INVALID")
            .MaximumLength(255).WithMessage("EMAIL_LENGTH_INVALID");

        RuleFor(x => x.Birthdate)
            .NotEmpty().WithMessage("BIRTHDATE_REQUIRED")
            .Must(BeValidAge).WithMessage("BIRTHDATE_PATTERN_INVALID");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("PASSWORD_REQUIRED")
            .MinimumLength(6).WithMessage("PASSWORD_LENGTH_INVALID")
            .MaximumLength(24).WithMessage("PASSWORD_LENGTH_INVALID");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("ROLE_PATTERN_INVALID");

        RuleFor(x => x.AvatarUrl)
            .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.AvatarUrl)).WithMessage("AVATAR_URL_PATTERN_INVALID")
            .MaximumLength(255).WithMessage("AVATAR_URL_LENGTH_INVALID");

        RuleFor(x => x.Biography)
            .MaximumLength(512).WithMessage("BIOGRAPHY_LENGTH_INVALID");
    }

    private bool BeValidAge(DateTime birthdate)
    {
        return birthdate <= DateTime.Now.AddYears(-18) && birthdate >= DateTime.Now.AddYears(-100);
    }

    private bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
