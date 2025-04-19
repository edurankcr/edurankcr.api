using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.RequestPasswordReset;

public record RequestPasswordResetCommand(string Identifier) : IRequest<ErrorOr<Unit>>;