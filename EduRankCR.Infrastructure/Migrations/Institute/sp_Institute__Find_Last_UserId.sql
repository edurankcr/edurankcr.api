CREATE PROCEDURE sp_Institute__Find_Last_UserId
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT InstituteId, UserId, Name, Type, Province, Url, Status
    FROM Institutes
    WHERE UserId = @UserId
    ORDER BY CreatedAt DESC
END;
