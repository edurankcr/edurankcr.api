using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.SendVerificationEmail;

internal sealed class SendVerificationEmailCommandHandler : IRequestHandler<SendVerificationEmailCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public SendVerificationEmailCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<Unit>> Handle(SendVerificationEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.EmailConfirmed)
        {
            return Errors.User.AlreadyConfirmed;
        }

        var existingToken = await _tokenRepository.GetValidEmailVerificationToken(user.UserId);

        if (existingToken is not null)
        {
            return Errors.Token.AlreadyExists;
        }

        var token = await _tokenRepository.GenerateEmailVerificationToken(user);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token },
            { "{{NAME}}", user.Name },
        };

        await _emailService.SendEmailAsync(
            user.Email,
            "Verify your email address - EduRankCR",
            "verification_email.html",
            placeholders);

        return Unit.Value;
    }
}