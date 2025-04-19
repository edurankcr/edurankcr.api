CREATE PROCEDURE usp_User_ConfirmEmail
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE Users
    SET EmailConfirmed = 1,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
