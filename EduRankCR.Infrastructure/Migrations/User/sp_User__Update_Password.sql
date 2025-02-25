CREATE PROCEDURE sp_User__Update_Password
    @UserId UNIQUEIDENTIFIER,
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET Password = @Password,
        UpdatedAt = GETUTCDATE()
    WHERE UserId = @UserId;
END;
