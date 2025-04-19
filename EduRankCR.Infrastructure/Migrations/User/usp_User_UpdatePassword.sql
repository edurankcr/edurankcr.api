CREATE PROCEDURE usp_User_UpdatePassword
    @UserId UNIQUEIDENTIFIER,
    @NewPassword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET Password = @NewPassword,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
