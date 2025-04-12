namespace EduRankCR.Contracts.Reviews;

public record ReviewTeacherDto(
    Guid TeacherId,
    string TeacherName,
    string TeacherLastName,
    Guid ReviewId,
    bool FreeCourse,
    string? CourseCode,
    int CourseMode,
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