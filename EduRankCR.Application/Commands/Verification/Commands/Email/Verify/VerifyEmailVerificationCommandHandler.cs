using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Verify;

public class VerifyEmailVerificationCommandHandler : IRequestHandler<VerifyEmailVerificationCommand, ErrorOr<BoolResult>>
{
    private readonly ITokenRepository _tokenRepository;

    public VerifyEmailVerificationCommandHandler(
        ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        VerifyEmailVerificationCommand query,
        CancellationToken cancellationToken)
    {
        Token? token = await _tokenRepository.Find(new TokenId(query.Token));

        if (token?.Id is null)
        {
            return Errors.Token.NotFound;
        }

        if (token.ExpiresAt < DateTime.Now)
        {
            return Errors.Token.AlreadyExpired;
        }

        switch (token.Status)
        {
            case TokenStatus.Used:
                return Errors.Token.AlreadyUsed;
            case TokenStatus.Invalid:
                return Errors.Token.InvalidToken;
        }

        await _tokenRepository.VerifyEmail(token.Id);

        return new BoolResult(true);
    }
}