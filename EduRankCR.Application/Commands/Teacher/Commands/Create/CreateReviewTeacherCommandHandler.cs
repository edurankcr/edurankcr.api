using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public class CreateReviewTeacherCommandHandler : IRequestHandler<CreateReviewTeacherCommand, ErrorOr<BoolResult>>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IInstituteRepository _instituteRepository;

    public CreateReviewTeacherCommandHandler(
        ITeacherRepository teacherRepository,
        IInstituteRepository instituteRepository)
    {
        _teacherRepository = teacherRepository;
        _instituteRepository = instituteRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        CreateReviewTeacherCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = UserId.ConvertFromString(query.UserId);
        TeacherId teacherId = TeacherId.ConvertFromString(query.TeacherId);
        InstituteId instituteId = InstituteId.ConvertFromString(query.InstituteId);

        TeacherReview? isReviewed = await _teacherRepository.FindReviewByTeacher(userId, teacherId);

        if (isReviewed?.Id is not null)
        {
            return Errors.Teacher.ReviewAlreadyExists;
        }

        Domain.TeacherAggregate.Entities.Teacher? teacher = await _teacherRepository.FindById(teacherId);

        if (teacher?.Id is null)
        {
            return Errors.Teacher.NotFound;
        }

        if (teacher.Status != Status.Active)
        {
            return Errors.Teacher.NotApproved;
        }

        Domain.InstituteAggregate.Entities.Institute? institute = await _instituteRepository.Find(instituteId);

        if (institute?.Id is null)
        {
            return Errors.Institute.NotFound;
        }

        if (institute.Status != Status.Active)
        {
            return Errors.Institute.NotApproved;
        }

        TeacherReview teacherReview = TeacherReview.Create(
            UserId.ConvertFromString(query.UserId),
            TeacherId.ConvertFromString(query.TeacherId),
            InstituteId.ConvertFromString(query.InstituteId),
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

        await _teacherRepository.CreateReview(userId, teacherId, instituteId, teacherReview);

        return new BoolResult(true);
    }
}