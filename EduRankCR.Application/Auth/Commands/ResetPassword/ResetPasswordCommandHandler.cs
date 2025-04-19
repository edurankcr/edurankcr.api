using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.ResetPassword;

internal sealed class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IPasswordHasher _passwordHasher;

    public ResetPasswordCommandHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<Unit>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
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

        await _userRepository.UpdatePassword(user.UserId, _passwordHasher.Hash(request.NewPassword));

        await _tokenRepository.MarkAsUsed(request.Token);

        return Unit.Value;
    }
}