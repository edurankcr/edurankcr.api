using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces.Auth;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Application.Common.Interfaces.Services;
using EduRankCR.Application.Register.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Password.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public ForgotPasswordCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ForgotPasswordCommand query,
        CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Find(query.Identifier);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.EmailConfirmed is false)
        {
            return Errors.User.EmailNotConfirmed;
        }

        Token token = Token.Create(user.Id.Value, DateTime.Now.AddMinutes(30));

        await _tokenRepository.Create(token);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token.Id.Value.ToString() },
            { "{{NAME}}", user.Name },
        };

        await _emailService.SendEmailAsync(
            user.Email,
            "Reset your password - EduRankCR",
            "reset_password_email.html",
            placeholders);

        return new BoolResult(true);
    }
}