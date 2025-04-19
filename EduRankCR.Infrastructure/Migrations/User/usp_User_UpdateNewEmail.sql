CREATE PROCEDURE usp_User_UpdateNewEmail
    @UserId UNIQUEIDENTIFIER,
    @NewEmail NVARCHAR(256)
AS
BEGIN
    UPDATE Users
    SET NewEmail = @NewEmail,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
