using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Verification.Commands.Email.Verify;

public record VerifyEmailVerificationCommand(string TokenId) : IRequest<ErrorOr<BoolResult>>;