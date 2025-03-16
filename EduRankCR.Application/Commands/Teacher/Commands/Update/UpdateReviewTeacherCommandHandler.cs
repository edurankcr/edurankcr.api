using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Teacher.Commands.Update;

public class UpdateReviewTeacherCommandHandler : IRequestHandler<UpdateReviewTeacherCommand, ErrorOr<BoolResult>>
{
    private readonly ITeacherRepository _teacherRepository;

    public UpdateReviewTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        UpdateReviewTeacherCommand query,
        CancellationToken cancellationToken)
    {
        if (new object?[]
            {
                query.FreeCourse,
                query.CourseCode,
                query.CourseMode,
                query.ProfessorRating,
                query.DifficultyRating,
                query.WouldTakeAgain,
                query.MandatoryAttendance,
                query.GradeReceived,
                query.ExperienceText,
            }.All(value => value is null))
        {
            return Errors.General.NothingToUpdate;
        }

        UserId userId = UserId.ConvertFromString(query.UserId);
        TeacherId teacherId = TeacherId.ConvertFromString(query.TeacherId);

        TeacherReview? recoverReview = await _teacherRepository.FindReviewByTeacher(userId, teacherId);

        if (recoverReview?.Id is null)
        {
            return Errors.Teacher.ReviewNotFound;
        }

        await _teacherRepository.UpdateReview(
            recoverReview.Id,
            query.FreeCourse,
            query.CourseCode,
            query.CourseMode,
            query.ProfessorRating,
            query.DifficultyRating,
            query.WouldTakeAgain,
            query.MandatoryAttendance,
            query.GradeReceived,
            query.ExperienceText);

        return new BoolResult(true);
    }
}