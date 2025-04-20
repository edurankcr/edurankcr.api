using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Teachers.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Teachers.Queries.GetById;

public sealed class GetTeacherByIdQueryHandler
    : IRequestHandler<GetTeacherByIdQuery, ErrorOr<TeacherResult>>
{
    private readonly ITeacherRepository _repository;

    public GetTeacherByIdQueryHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<TeacherResult>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetById(request.TeacherId);

        if (teacher is null)
        {
            return Errors.Teacher.NotFound;
        }

        return new TeacherResult(
            teacher.TeacherId,
            teacher.Name,
            teacher.LastName,
            teacher.Biography,
            teacher.AvatarUrl,
            teacher.CreatedAt,
            teacher.UpdatedAt);
    }
}