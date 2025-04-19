using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.DeleteEmailChange;

public sealed record DeleteEmailChangeCommand(Guid UserId) : IRequest<ErrorOr<Unit>>;