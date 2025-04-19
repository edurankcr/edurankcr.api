CREATE PROCEDURE usp_UserToken_Create
    @UserId UNIQUEIDENTIFIER,
    @Token NVARCHAR(255),
    @Type TINYINT,
    @ExpiresAt DATETIME2
AS
BEGIN
    INSERT INTO Users_Tokens (UserId, Token, Type, ExpiresAt)
    VALUES (@UserId, @Token, @Type, @ExpiresAt);
END
