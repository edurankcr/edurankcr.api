using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Common.Enums;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Account.Commands.VerifyEmailChange;

public sealed class VerifyEmailChangeCommandHandler : IRequestHandler<VerifyEmailChangeCommand, ErrorOr<Unit>>
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUserRepository _userRepository;

    public VerifyEmailChangeCommandHandler(ITokenRepository tokenRepository, IUserRepository userRepository)
    {
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(VerifyEmailChangeCommand request, CancellationToken cancellationToken)
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

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        if (user.NewEmail is null)
        {
            return Errors.User.NullNewEmail;
        }

        var userExists = await _userRepository.GetByEmail(user.NewEmail);

        await _tokenRepository.MarkAsUsed(request.Token);
        await _userRepository.UpdateNewEmail(user.UserId, null);

        if (userExists is not null)
        {
            await _tokenRepository.DeleteAllByUserId(user.UserId, TokenType.EmailVerification);

            return Errors.User.DuplicateEmail;
        }

        await _userRepository.UpdateEmail(user.UserId, user.NewEmail);

        return Unit.Value;
    }
}