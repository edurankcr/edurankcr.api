using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Auth;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Password.Commands.Reset;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ErrorOr<BoolResult>>
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IPasswordHasher _passwordHasher;

    public ResetPasswordCommandHandler(
        ITokenRepository tokenRepository,
        IPasswordHasher passwordHasher)
    {
        _tokenRepository = tokenRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ResetPasswordCommand query,
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

        await _tokenRepository.VerifyPassword(token.Id, _passwordHasher.HashPassword(query.NewPassword));

        return new BoolResult(true);
    }
}