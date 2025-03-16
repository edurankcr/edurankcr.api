using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
    Task CreateReview(TeacherReview teacherReview, Teacher teacher, UserId userId);
    Task UpdateReview(
        ReviewId reviewId,
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