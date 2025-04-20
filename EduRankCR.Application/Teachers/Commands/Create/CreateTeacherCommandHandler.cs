using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Teachers.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Teachers;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Teachers.Commands.Create;

internal sealed class CreateTeacherCommandHandler
    : IRequestHandler<CreateTeacherCommand, ErrorOr<CreatedTeacherResult>>
{
    private readonly ITeacherRepository _repository;

    public CreateTeacherCommandHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CreatedTeacherResult>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var existingPendingTeacher = await _repository.ExistsPendingByUserId(request.UserId);

        if (existingPendingTeacher)
        {
            return Errors.Teacher.AlreadyInReview;
        }

        var teacher = Teacher.Create(
            request.UserId,
            request.Name,
            request.LastName,
            request.Biography,
            null,
            Status.InReview);

        await _repository.Create(teacher);

        return new CreatedTeacherResult(teacher.TeacherId);
    }
}