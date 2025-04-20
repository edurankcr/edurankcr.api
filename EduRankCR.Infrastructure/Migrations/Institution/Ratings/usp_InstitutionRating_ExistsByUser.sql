CREATE OR ALTER PROCEDURE usp_InstitutionRating_ExistsByUser
    @InstitutionId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Institutions_Ratings
        WHERE InstitutionId = @InstitutionId
          AND UserId = @UserId
    )
    BEGIN
        SELECT 1;
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END;
