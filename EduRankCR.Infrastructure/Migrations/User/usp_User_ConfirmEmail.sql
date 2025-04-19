CREATE PROCEDURE usp_User_ConfirmEmail
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET EmailConfirmed = 1,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
