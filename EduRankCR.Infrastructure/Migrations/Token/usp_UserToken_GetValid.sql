CREATE PROCEDURE usp_UserToken_GetValid
    @UserId UNIQUEIDENTIFIER,
    @Type TINYINT,
    @Now DATETIME2
AS
BEGIN
    SELECT TOP 1 Token
    FROM Users_Tokens
    WHERE UserId = @UserId
      AND Type = @Type
      AND ExpiresAt > @Now
    ORDER BY CreatedAt DESC;
END
