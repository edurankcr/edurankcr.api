using FluentValidation;
using EduRankCR.Application.DTOs.Request;

public class RequestUserUpdateDtoValidator : AbstractValidator<RequestUserUpdateDto>
{
    public RequestUserUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(32).WithMessage("NAME_LENGTH_INVALID");

        RuleFor(x => x.LastName)
            .MaximumLength(64).WithMessage("LASTNAME_LENGTH_INVALID");

        RuleFor(x => x.Username)
            .Matches(@"^[a-zA-Z0-9._]+$").When(x => !string.IsNullOrEmpty(x.Username)).WithMessage("USERNAME_PATTERN_INVALID")
            .MaximumLength(18).WithMessage("USERNAME_LENGTH_INVALID");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("EMAIL_PATTERN_INVALID")
            .MaximumLength(255).WithMessage("EMAIL_LENGTH_INVALID");

        RuleFor(x => x.Birthdate)
            .Must(BeValidAge).When(x => x.Birthdate.HasValue).WithMessage("BIRTHDATE_PATTERN_INVALID");

        RuleFor(x => x.Role)
            .IsInEnum().When(x => x.Role.HasValue).WithMessage("ROLE_PATTERN_INVALID");

        RuleFor(x => x.Status)
            .IsInEnum().When(x => x.Status.HasValue).WithMessage("STATUS_PATTERN_INVALID");

        RuleFor(x => x.AvatarUrl)
            .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.AvatarUrl)).WithMessage("AVATAR_URL_PATTERN_INVALID")
            .MaximumLength(255).WithMessage("AVATAR_URL_LENGTH_INVALID");

        RuleFor(x => x.Biography)
            .MaximumLength(512).WithMessage("BIOGRAPHY_LENGTH_INVALID");
    }

    private bool BeValidAge(DateTime? birthdate)
    {
        if (!birthdate.HasValue)
            return true;
        return birthdate.Value <= DateTime.Now.AddYears(-18) && birthdate.Value >= DateTime.Now.AddYears(-100);
    }

    private bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}