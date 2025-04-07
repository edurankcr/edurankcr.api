using FluentValidation;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Delete;

public class DeleteEmailChangeProfileCommandValidator : AbstractValidator<DeleteEmailChangeProfileCommand>
{
    public DeleteEmailChangeProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");
    }
}