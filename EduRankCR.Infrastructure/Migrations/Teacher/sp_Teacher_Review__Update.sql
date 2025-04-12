CREATE PROCEDURE sp_Teacher_Review__Update
    @ReviewId   UNIQUEIDENTIFIER,
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
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Teachers_Reviews
        SET
            InstituteId         = COALESCE(@InstituteId, InstituteId),
            FreeCourse          = COALESCE(@FreeCourse, FreeCourse),
            CourseCode          = COALESCE(@CourseCode, CourseCode),
            CourseMode          = COALESCE(@CourseMode, CourseMode),
            ProfessorRating     = COALESCE(@ProfessorRating, ProfessorRating),
            DifficultyRating    = COALESCE(@DifficultyRating, DifficultyRating),
            WouldTakeAgain      = COALESCE(@WouldTakeAgain, WouldTakeAgain),
            MandatoryAttendance = COALESCE(@MandatoryAttendance, MandatoryAttendance),
            GradeReceived       = COALESCE(@GradeReceived, GradeReceived),
            ExperienceText      = COALESCE(@ExperienceText, ExperienceText),
            Status              = COALESCE(@Status, Status),
            UpdatedAt           = SYSUTCDATETIME()
        WHERE ReviewId = @ReviewId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
