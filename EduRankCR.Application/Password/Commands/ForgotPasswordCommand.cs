using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Password.Commands;

public record ForgotPasswordCommand(string Identifier) : IRequest<ErrorOr<BoolResult>>;