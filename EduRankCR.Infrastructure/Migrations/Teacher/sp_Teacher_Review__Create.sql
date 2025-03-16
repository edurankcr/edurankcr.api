CREATE PROCEDURE sp_Teacher_Review__Create
(
    @UserId UNIQUEIDENTIFIER,
    @TeacherId UNIQUEIDENTIFIER,
    @InstituteId UNIQUEIDENTIFIER,
    @FreeCourse BIT,
    @CourseCode NVARCHAR(64) = NULL,
    @CourseMode TINYINT,
    @ProfessorRating DECIMAL(2,1),
    @DifficultyRating DECIMAL(2,1),
    @WouldTakeAgain BIT = NULL,
    @MandatoryAttendance BIT = NULL,
    @GradeReceived NVARCHAR(5) = NULL,
    @ExperienceText NVARCHAR(510),
    @Status TINYINT = 0,
    @CreatedAt DATETIME2 = NULL,
    @UpdatedAt DATETIME2 = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @CreatedAt IS NULL SET @CreatedAt = GETDATE();
    IF @UpdatedAt IS NULL SET @UpdatedAt = GETDATE();

    INSERT INTO Teacher_Reviews (
        ReviewId, UserId, TeacherId, InstituteId, FreeCourse, CourseCode, CourseMode,
        ProfessorRating, DifficultyRating, WouldTakeAgain, MandatoryAttendance,
        GradeReceived, ExperienceText, Status, CreatedAt, UpdatedAt
    )
    VALUES (
               NEWID(), @UserId, @TeacherId, @InstituteId, @FreeCourse, @CourseCode, @CourseMode,
               @ProfessorRating, @DifficultyRating, @WouldTakeAgain, @MandatoryAttendance,
               @GradeReceived, @ExperienceText, @Status, @CreatedAt, @UpdatedAt
           );
END;
