using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Profile.Commands.Email;

public class VerifyChangeEmailCommandHandler : IRequestHandler<VerifyChangeEmailCommand, ErrorOr<BoolResult>>
{
    private readonly ITokenRepository _tokenRepository;

    public VerifyChangeEmailCommandHandler(
        ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        VerifyChangeEmailCommand query,
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

        await _tokenRepository.VerifyChangeEmail(token.Id);

        return new BoolResult(true);
    }
}