using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.DeleteEmailChange;

public sealed class DeleteEmailChangeCommandHandler : IRequestHandler<DeleteEmailChangeCommand, ErrorOr<Unit>>
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUserRepository _userRepository;

    public DeleteEmailChangeCommandHandler(ITokenRepository tokenRepository, IUserRepository userRepository)
    {
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteEmailChangeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

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

        await _tokenRepository.DeleteAllByUserId(user.UserId, TokenType.EmailVerification);

        await _userRepository.UpdateNewEmail(user.UserId, null);

        return Unit.Value;
    }
}