CREATE PROCEDURE usp_UpdateUserAvatarUrl
    @UserId UNIQUEIDENTIFIER,
    @AvatarUrl NVARCHAR(500)
AS
BEGIN
    UPDATE Users
    SET AvatarUrl = @AvatarUrl
    WHERE UserId = @UserId
END
