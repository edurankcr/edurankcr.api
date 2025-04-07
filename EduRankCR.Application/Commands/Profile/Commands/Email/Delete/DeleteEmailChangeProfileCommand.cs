using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Delete;

public record DeleteEmailChangeProfileCommand(string UserId) : IRequest<ErrorOr<BoolResult>>;