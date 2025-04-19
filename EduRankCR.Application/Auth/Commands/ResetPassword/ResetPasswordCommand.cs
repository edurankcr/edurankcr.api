using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.ResetPassword;

public record ResetPasswordCommand(string Token, string NewPassword) : IRequest<ErrorOr<Unit>>;