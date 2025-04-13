using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.ValueObjects;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
    Task CreateReview(UserId userId, TeacherId teacherId, InstituteId instituteId, TeacherReview teacherReview);
    Task UpdateReview(
        ReviewId reviewId,
        InstituteId? instituteId,
        bool? freeCourse,
        string? courseCode,
        int? courseMode,
        decimal? professorRating,
        decimal? difficultyRating,
        bool? wouldTakeAgain,
        bool? mandatoryAttendance,
        string? gradeReceived,
        string? experienceText);
    Task<TeacherReview?> FindReviewByTeacher(UserId userId, TeacherId teacherId);
    Task<Teacher?> FindById(TeacherId userId);
}