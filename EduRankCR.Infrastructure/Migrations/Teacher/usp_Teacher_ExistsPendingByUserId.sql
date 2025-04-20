CREATE PROCEDURE usp_Teacher_ExistsPendingByUserId
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 1
    FROM Teachers
    WHERE UserId = @UserId AND Status = 0;
END;
