CREATE PROCEDURE sp_Teacher_Review__Find_TeacherId
    @UserId UNIQUEIDENTIFIER,
    @TeacherId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ReviewId, UserId, TeacherId, InstituteId, FreeCourse, CourseCode, CourseMode,
           ProfessorRating, DifficultyRating, WouldTakeAgain, MandatoryAttendance,
           GradeReceived, ExperienceText, Status, CreatedAt, UpdatedAt
    FROM Teachers_Reviews
    WHERE UserId = @UserId AND TeacherId = @TeacherId;
END;
