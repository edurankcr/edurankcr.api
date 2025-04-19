using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.ChangePassword;

public record ChangePasswordCommand(
    Guid UserId,
    string CurrentPassword,
    string NewPassword) : IRequest<ErrorOr<Unit>>;