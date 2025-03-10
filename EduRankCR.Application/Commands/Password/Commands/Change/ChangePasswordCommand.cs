using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Password.Commands.Change;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword, string UserId) : IRequest<ErrorOr<BoolResult>>;