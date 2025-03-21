﻿using FluentValidation;

namespace EduRankCR.Application.Commands.Password.Commands.Change;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid UserId format.");

        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);
    }
}