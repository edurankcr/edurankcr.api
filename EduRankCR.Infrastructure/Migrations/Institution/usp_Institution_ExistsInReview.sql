CREATE PROCEDURE usp_Institution_ExistsInReview
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Institutions
        WHERE UserId = @UserId
          AND Status = 0
    )
        BEGIN
            SELECT CAST(1 AS BIT);
        END
    ELSE
        BEGIN
            SELECT CAST(0 AS BIT);
        END
END;
