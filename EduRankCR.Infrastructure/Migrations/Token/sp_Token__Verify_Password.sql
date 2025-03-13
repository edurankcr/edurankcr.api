CREATE PROCEDURE sp_Token__Verify_Password
    @TokenId UNIQUEIDENTIFIER,
    @Password NVARCHAR(255),
    @MaxAttempts INT = 5
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @UserId UNIQUEIDENTIFIER;
    DECLARE @Attempts INT;

    SELECT @UserId = UserId, @Attempts = Attempts
    FROM Tokens WITH (UPDLOCK, ROWLOCK)
    WHERE TokenId = @TokenId AND Status = 0;

    IF @UserId IS NOT NULL AND @Attempts >= @MaxAttempts
        BEGIN
            UPDATE Tokens
            SET Status = 2
            WHERE TokenId = @TokenId;

            COMMIT TRANSACTION;
            RETURN;
        END;

    IF @UserId IS NOT NULL
        BEGIN
            UPDATE Users
            SET Password = @Password,
                PasswordChangedAt = GETDATE()
            WHERE UserID = @UserId;

            UPDATE Tokens
            SET Status = 1, Attempts = @Attempts + 1
            WHERE TokenId = @TokenId;
        END;

    COMMIT TRANSACTION;
END;
