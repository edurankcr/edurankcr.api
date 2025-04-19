using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.DeleteAvatar;

public sealed record DeleteAvatarCommand(Guid UserId) : IRequest<ErrorOr<Success>>;