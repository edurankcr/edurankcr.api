CREATE PROCEDURE usp_User_UpdatePassword
    @UserId UNIQUEIDENTIFIER,
    @NewPassword NVARCHAR(255)
AS
BEGIN
    UPDATE Users
    SET Password = @NewPassword,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
