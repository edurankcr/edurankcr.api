using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Password.Commands.Forgot;

public record ForgotPasswordCommand(string Identifier) : IRequest<ErrorOr<BoolResult>>;