using EduRankCR.Domain.TeacherAggregate.Enums;

namespace EduRankCR.Domain.Common.Projections;

public record ReviewTeacherProjection(
    Guid TeacherId,
    string TeacherName,
    string TeacherLastName,
    Guid ReviewId,
    bool FreeCourse,
    string? CourseCode,
    CourseMode CourseMode,
    decimal ProfessorRating,
    decimal DifficultyRating,
    bool? WouldTakeAgain,
    bool? MandatoryAttendance,
    string? GradeReceived,
    string ExperienceText,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string UserFirstName,
    string UserLastName,
    string UserName,
    string? AvatarUrl);