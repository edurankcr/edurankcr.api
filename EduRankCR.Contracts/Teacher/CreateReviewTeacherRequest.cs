﻿namespace EduRankCR.Contracts.Teacher;

public record CreateReviewTeacherRequest(
    string InstituteId,
    bool FreeCourse,
    string? CourseCode,
    int CourseMode,
    decimal ProfessorRating,
    decimal DifficultyRating,
    bool? WouldTakeAgain,
    bool? MandatoryAttendance,
    string? GradeReceived,
    string ExperienceText);