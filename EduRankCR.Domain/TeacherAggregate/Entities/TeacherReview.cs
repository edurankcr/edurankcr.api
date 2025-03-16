using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.TeacherAggregate.Entities;

public sealed class TeacherReview : Entity<ReviewId>
{
    public UserId UserId { get; }
    public TeacherId TeacherId { get; }
    public InstituteId InstituteId { get; }
    public bool FreeCourse { get; }
    public string? CourseCode { get; }
    public CourseMode CourseMode { get; }
    public decimal ProfessorRating { get; }
    public decimal DifficultyRating { get; }
    public bool? WouldTakeAgain { get; }
    public bool? MandatoryAttendance { get; }
    public string? GradeReceived { get; }
    public string ExperienceText { get; }
    public Status Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private TeacherReview(
        ReviewId reviewId,
        UserId userId,
        TeacherId teacherId,
        InstituteId instituteId,
        bool freeCourse,
        string? courseCode,
        CourseMode courseMode,
        decimal professorRating,
        decimal difficultyRating,
        bool? wouldTakeAgain,
        bool? mandatoryAttendance,
        string? gradeReceived,
        string experienceText,
        Status status,
        DateTime createdAt,
        DateTime updatedAt)
        : base(reviewId)
    {
        UserId = userId;
        TeacherId = teacherId;
        InstituteId = instituteId;
        FreeCourse = freeCourse;
        CourseCode = courseCode;
        CourseMode = courseMode;
        ProfessorRating = professorRating;
        DifficultyRating = difficultyRating;
        WouldTakeAgain = wouldTakeAgain;
        MandatoryAttendance = mandatoryAttendance;
        GradeReceived = gradeReceived;
        ExperienceText = experienceText;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static TeacherReview Create(
        UserId userId,
        TeacherId teacherId,
        InstituteId instituteId,
        bool freeCourse,
        string? courseCode,
        CourseMode courseMode,
        decimal professorRating,
        decimal difficultyRating,
        bool? wouldTakeAgain,
        bool? mandatoryAttendance,
        string? gradeReceived,
        string experienceText,
        Status status)
    {
        return new TeacherReview(
            ReviewId.CreateUnique(),
            userId,
            teacherId,
            instituteId,
            freeCourse,
            courseCode,
            courseMode,
            professorRating,
            difficultyRating,
            wouldTakeAgain,
            mandatoryAttendance,
            gradeReceived,
            experienceText,
            status,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public static TeacherReview CreateFromPersistence(
        Guid reviewId,
        Guid userId,
        Guid teacherId,
        Guid instituteId,
        bool freeCourse,
        string? courseCode,
        byte courseMode,
        decimal professorRating,
        decimal difficultyRating,
        bool? wouldTakeAgain,
        bool? mandatoryAttendance,
        string? gradeReceived,
        string experienceText,
        byte status,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new TeacherReview(
            new ReviewId(reviewId),
            new UserId(userId),
            new TeacherId(teacherId),
            new InstituteId(instituteId),
            freeCourse,
            courseCode,
            (CourseMode)courseMode,
            professorRating,
            difficultyRating,
            wouldTakeAgain,
            mandatoryAttendance,
            gradeReceived,
            experienceText,
            (Status)status,
            createdAt,
            updatedAt);
    }
}