using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.ConfirmVerificationEmail;

internal sealed class ConfirmVerificationEmailCommandHandler : IRequestHandler<ConfirmVerificationEmailCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public ConfirmVerificationEmailCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(ConfirmVerificationEmailCommand request, CancellationToken cancellationToken)
    {
        var userId = await _tokenRepository.GetUserIdByVerificationToken(request.Token);

        if (userId is null)
        {
            return Errors.Token.NotFound;
        }

        var user = await _userRepository.GetById(userId.Value);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.EmailConfirmed)
        {
            return Errors.User.AlreadyConfirmed;
        }

        await _userRepository.ConfirmEmail(user.UserId);

        await _tokenRepository.MarkAsUsed(request.Token);

        return Unit.Value;
    }
}