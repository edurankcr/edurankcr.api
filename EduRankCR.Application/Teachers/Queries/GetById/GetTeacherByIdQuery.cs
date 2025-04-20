using EduRankCR.Application.Teachers.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Teachers.Queries.GetById;

public sealed record GetTeacherByIdQuery(Guid TeacherId)
    : IRequest<ErrorOr<TeacherResult>>;