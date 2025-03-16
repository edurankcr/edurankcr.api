CREATE PROCEDURE sp_TeacherReview__Find_Id_TeacherId
    @UserId UNIQUEIDENTIFIER,
    @TeacherId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ReviewId, UserId, TeacherId, FreeCourse, CourseCode, CourseMode,
           ProfessorRating, DifficultyRating, WouldTakeAgain, MandatoryAttendance,
           GradeReceived, ExperienceText, Status, CreatedAt, UpdatedAt
    FROM TeachersReviews
    WHERE UserId = @UserId AND TeacherId = @TeacherId;
END;
