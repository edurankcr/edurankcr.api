using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public record CreateReviewTeacherCommand(
    bool FreeCourse,
    string? CourseCode,
    int CourseMode,
    decimal ProfessorRating,
    decimal DifficultyRating,
    bool? WouldTakeAgain,
    bool? MandatoryAttendance,
    string? GradeReceived,
    string ExperienceText,
    string UserId,
    string TeacherId) : IRequest<ErrorOr<BoolResult>>;