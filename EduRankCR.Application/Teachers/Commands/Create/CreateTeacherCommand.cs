using EduRankCR.Application.Teachers.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Teachers.Commands.Create;

public sealed record CreateTeacherCommand(
    Guid UserId,
    string Name,
    string LastName,
    string? Biography)
    : IRequest<ErrorOr<CreatedTeacherResult>>;