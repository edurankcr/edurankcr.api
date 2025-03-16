namespace EduRankCR.Contracts.Teacher;

public record ReviewTeacherRequest(
    bool FreeCourse,
    string? CourseCode,
    int CourseMode,
    decimal ProfessorRating,
    decimal DifficultyRating,
    bool? WouldTakeAgain,
    bool? MandatoryAttendance,
    string? GradeReceived,
    string ExperienceText);