using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Enums;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
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
    private readonly IInstituteRepository _instituteRepository;

    public UpdateReviewTeacherCommandHandler(
        ITeacherRepository teacherRepository,
        IInstituteRepository instituteRepository)
    {
        _teacherRepository = teacherRepository;
        _instituteRepository = instituteRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        UpdateReviewTeacherCommand query,
        CancellationToken cancellationToken)
    {
        if (new object?[]
            {
                query.InstituteId,
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
        InstituteId? instituteId = query.InstituteId is not null ? InstituteId.ConvertFromString(query.InstituteId) : null;

        TeacherReview? recoverReview = await _teacherRepository.FindReviewByTeacher(userId, teacherId);

        if (recoverReview?.Id is null)
        {
            return Errors.Teacher.ReviewNotFound;
        }

        if (instituteId?.Value is not null)
        {
            Domain.InstituteAggregate.Entities.Institute? institute = await _instituteRepository.Find(instituteId);

            if (institute?.Id is null)
            {
                return Errors.Institute.NotFound;
            }

            if (institute.Status != Status.Active)
            {
                return Errors.Institute.NotApproved;
            }
        }

        await _teacherRepository.UpdateReview(
            recoverReview.Id,
            instituteId,
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