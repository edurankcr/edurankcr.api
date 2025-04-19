CREATE PROCEDURE usp_UserToken_DeleteAllByUserId
    @UserId UNIQUEIDENTIFIER,
    @Type TINYINT
AS
BEGIN
    DELETE FROM Users_Tokens
    WHERE UserId = @UserId AND Type = @Type;
END;
