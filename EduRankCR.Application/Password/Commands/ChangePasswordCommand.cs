using EduRankCR.Application.Common;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Password.Commands;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword, string UserId) : IRequest<ErrorOr<BoolResult>>;