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

namespace EduRankCR.Application.Commands.Teacher.Commands.Review;

public class ReviewTeacherCommandHandler : IRequestHandler<ReviewTeacherCommand, ErrorOr<BoolResult>>
{
    private readonly ITeacherRepository _teacherRepository;

    public ReviewTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ReviewTeacherCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = UserId.ConvertFromString(query.UserId);
        TeacherId teacherId = TeacherId.ConvertFromString(query.TeacherId);

        TeacherReview? isReviewed = await _teacherRepository.IsReviewed(userId, teacherId);

        if (isReviewed?.Id is not null)
        {
            return Errors.Teacher.ReviewAlreadyExists;
        }

        Domain.TeacherAggregate.Entities.Teacher? teacher = await _teacherRepository.FindById(teacherId);

        if (teacher?.Id is null)
        {
            return Errors.Teacher.NotFound;
        }

        if (teacher.Status != TeacherStatus.Approved)
        {
            return Errors.Teacher.NotApproved;
        }

        TeacherReview review = TeacherReview.Create(
            UserId.ConvertFromString(query.UserId),
            TeacherId.ConvertFromString(query.TeacherId),
            query.FreeCourse,
            query.CourseCode,
            (CourseMode)query.CourseMode,
            query.ProfessorRating,
            query.DifficultyRating,
            query.WouldTakeAgain,
            query.MandatoryAttendance,
            query.GradeReceived,
            query.ExperienceText,
            Status.Pending);

        await _teacherRepository.CreateReview(review, teacher, userId);

        return new BoolResult(true);
    }
}