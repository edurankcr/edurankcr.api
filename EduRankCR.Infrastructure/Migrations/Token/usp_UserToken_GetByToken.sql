CREATE PROCEDURE usp_UserToken_GetByToken
    @Token NVARCHAR(255),
    @Now DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 UserId
    FROM Users_Tokens
    WHERE Token = @Token
      AND ExpiresAt > @Now;
END
