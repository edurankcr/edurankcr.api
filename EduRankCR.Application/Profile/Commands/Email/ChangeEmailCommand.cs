using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Profile.Commands.Email;

public record ChangeEmailCommand(
    string NewEmail,
    string UserId) : IRequest<ErrorOr<BoolResult>>;