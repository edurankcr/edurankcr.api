using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.RequestPasswordReset;

public record RequestPasswordResetCommand(string Email) : IRequest<ErrorOr<Unit>>;