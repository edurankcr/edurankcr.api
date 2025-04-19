using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Account.Commands.ChangeEmail;

public sealed class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public ChangeEmailCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<Unit>> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.Email == request.NewEmail)
        {
            return Errors.User.SameEmail;
        }

        var emailExists = await _userRepository.IsEmailTaken(request.NewEmail);

        if (emailExists)
        {
            return Errors.User.DuplicateEmail;
        }

        var existingToken = await _tokenRepository.GetValidEmailVerificationToken(user.UserId);

        if (existingToken is not null)
        {
            return Errors.Token.AlreadyExists;
        }

        var token = await _tokenRepository.GenerateEmailVerificationToken(user);

        await _userRepository.UpdateNewEmail(user.UserId, request.NewEmail);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token },
            { "{{NAME}}", user.Name },
            { "{{NEW_EMAIL}}", request.NewEmail },
            { "{{OLD_EMAIL}}", user.Email },
        };

        await _emailService.SendEmailAsync(
            request.NewEmail,
            "Change Email Request - EduRankCR",
            "change_email.html",
            placeholders);

        return Unit.Value;
    }
}