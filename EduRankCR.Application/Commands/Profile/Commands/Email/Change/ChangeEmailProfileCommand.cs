using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Change;

public record ChangeEmailProfileCommand(
    string NewEmail,
    string UserId) : IRequest<ErrorOr<BoolResult>>;