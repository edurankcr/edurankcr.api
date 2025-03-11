using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public record CreateTeacherCommand(
    string Name,
    string LastName,
    string InstituteId,
    string UserId) : IRequest<ErrorOr<BoolResult>>;