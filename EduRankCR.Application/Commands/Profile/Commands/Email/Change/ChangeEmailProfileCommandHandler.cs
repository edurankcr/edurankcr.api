﻿using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Change;

public class ChangeEmailProfileCommandHandler : IRequestHandler<ChangeEmailProfileCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public ChangeEmailProfileCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ChangeEmailProfileCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = UserId.ConvertFromString(query.UserId);
        User? user = await _userRepository.FindById(userId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.Email.Equals(query.NewEmail))
        {
            return Errors.User.EmailCurrentInUse;
        }

        if (query.NewEmail != user.Email)
        {
            User? userConfirmed = await _userRepository.Find(query.NewEmail);

            if (userConfirmed is not null && userConfirmed.EmailConfirmed)
            {
                return Errors.User.EmailTaken;
            }
        }

        await _userRepository.UpdateEmail(userId, query.NewEmail, true);

        Token token = Token.Create(user.Id.Value, DateTime.Now.AddMinutes(30));

        await _tokenRepository.Create(token);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token.Id.Value.ToString() },
            { "{{NAME}}", user.Name },
            { "{{NEW_EMAIL}}", query.NewEmail },
            { "{{OLD_EMAIL}}", user.Email },
        };

        await _emailService.SendEmailAsync(
            query.NewEmail,
            "Change Email Request - EduRankCR",
            "change_email.html",
            placeholders);

        return new BoolResult(true);
    }
}