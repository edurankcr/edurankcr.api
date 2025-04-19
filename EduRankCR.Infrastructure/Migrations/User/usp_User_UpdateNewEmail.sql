CREATE PROCEDURE usp_User_UpdateNewEmail
    @UserId UNIQUEIDENTIFIER,
    @NewEmail NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET NewEmail = @NewEmail,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
