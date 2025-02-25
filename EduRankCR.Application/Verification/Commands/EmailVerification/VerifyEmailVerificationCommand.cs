using EduRankCR.Application.Verification.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Verification.Commands.EmailVerification;

public record VerifyEmailVerificationCommand(Guid Token) : IRequest<ErrorOr<VerifyEmailVerificationResult>>;