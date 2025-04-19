using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Account.Commands.ChangeEmail;

public sealed record ChangeEmailCommand(Guid UserId, string NewEmail) : IRequest<ErrorOr<Unit>>;