CREATE PROCEDURE sp_User__Delete_Change_Email
@UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Tokens
    WHERE UserId = @UserId
      AND Status = 0
      AND ExpiresAt > GETDATE();

    UPDATE Users
    SET NewEmail = NULL
    WHERE UserId = @UserId;
END;
