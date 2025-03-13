using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Request;

public class RequestEmailVerificationCommandHandler : IRequestHandler<RequestEmailVerificationCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IEmailService _emailService;

    public RequestEmailVerificationCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _emailService = emailService;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        RequestEmailVerificationCommand query,
        CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Find(query.Email);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.EmailConfirmed)
        {
            return Errors.User.EmailAlreadyConfirmed;
        }

        Token token = Token.Create(user.Id.Value, DateTime.Now.AddHours(48));

        await _tokenRepository.Create(token);

        var placeholders = new Dictionary<string, string>
        {
            { "{{TOKEN}}", token.Id.Value.ToString() },
            { "{{NAME}}", user.Name },
        };

        await _emailService.SendEmailAsync(
            user.Email,
            "Verify your email address - EduRankCR",
            "verification_email.html",
            placeholders);

        return new BoolResult(true);
    }
}