using EduRankCR.Application.Verification.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Verification.Commands.EmailVerification;

public record RequestEmailVerificationCommand(string Email) : IRequest<ErrorOr<RequestEmailVerificationResult>>;