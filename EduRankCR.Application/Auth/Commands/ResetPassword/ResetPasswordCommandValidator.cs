﻿using FluentValidation;

namespace EduRankCR.Application.Auth.Commands.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("TokenId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid TokenId format.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(32);
    }
}