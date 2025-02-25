CREATE PROCEDURE sp_User__Update_Email
    @UserId UNIQUEIDENTIFIER,
    @Email NVARCHAR(255),
    @IsNewEmail BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF @IsNewEmail = 1
        BEGIN
            UPDATE Users
            SET NewEmail = @Email
            WHERE UserId = @UserId;
        END
    ELSE
        BEGIN
            UPDATE Users
            SET Email = @Email
            WHERE UserId = @UserId;
        END
END;
