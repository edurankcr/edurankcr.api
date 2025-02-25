using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Password.Commands;

public record ResetPasswordCommand(Guid Token, string NewPassword) : IRequest<ErrorOr<BoolResult>>;