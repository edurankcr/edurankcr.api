using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.ConfirmVerificationEmail;

public record ConfirmVerificationEmailCommand(string Token) : IRequest<ErrorOr<Unit>>;