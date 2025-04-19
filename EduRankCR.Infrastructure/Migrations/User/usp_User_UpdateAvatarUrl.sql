CREATE PROCEDURE usp_User_UpdateAvatarUrl
    @UserId UNIQUEIDENTIFIER,
    @AvatarUrl NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET AvatarUrl = @AvatarUrl
    WHERE UserId = @UserId
END
