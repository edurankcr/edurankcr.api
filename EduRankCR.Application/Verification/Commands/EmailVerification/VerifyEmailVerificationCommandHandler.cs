using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Application.Verification.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Verification.Commands.EmailVerification;

public class VerifyEmailVerificationCommandHandler : IRequestHandler<VerifyEmailVerificationCommand, ErrorOr<VerifyEmailVerificationResult>>
{
    private readonly ITokenRepository _tokenRepository;

    public VerifyEmailVerificationCommandHandler(
        ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<ErrorOr<VerifyEmailVerificationResult>> Handle(
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

        return new VerifyEmailVerificationResult(true);
    }
}