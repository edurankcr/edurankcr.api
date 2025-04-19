using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.RequestPasswordReset;

public class RequestPasswordResetCommandHandler : IRequestHandler<RequestPasswordResetCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public RequestPasswordResetCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<Unit>> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdentifier(request.Identifier);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        var existingToken = await _tokenRepository.GetValidPasswordResetToken(user.UserId);

        if (existingToken is not null)
        {
            return Errors.Token.AlreadyExists;
        }

        var token = await _tokenRepository.GeneratePasswordResetToken(user.UserId);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token },
            { "{{NAME}}", user.Name },
        };

        await _emailService.SendEmailAsync(
            user.Email,
            "Reset your password - EduRankCR",
            "reset_password_email.html",
            placeholders);

        return Unit.Value;
    }
}