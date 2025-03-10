using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Verify;

public record VerifyEmailProfileCommand(Guid Token) : IRequest<ErrorOr<BoolResult>>;