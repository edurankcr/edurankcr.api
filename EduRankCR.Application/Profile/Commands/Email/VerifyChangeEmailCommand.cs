using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Profile.Commands.Email;

public record VerifyChangeEmailCommand(Guid Token) : IRequest<ErrorOr<BoolResult>>;