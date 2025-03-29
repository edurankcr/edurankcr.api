CREATE PROCEDURE sp_Token__Find_UserId
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 TokenId, UserId, Status, CreatedAt, ExpiresAt
    FROM Tokens
    WHERE UserId = @UserId
    ORDER BY CreatedAt DESC;
END;
