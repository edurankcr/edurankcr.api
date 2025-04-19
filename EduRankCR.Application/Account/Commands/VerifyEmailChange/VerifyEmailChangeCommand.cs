using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Account.Commands.VerifyEmailChange;

public sealed record VerifyEmailChangeCommand(string Token) : IRequest<ErrorOr<Unit>>;