using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Request;

public record RequestEmailVerificationCommand(string Email) : IRequest<ErrorOr<BoolResult>>;