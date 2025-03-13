CREATE PROCEDURE sp_Token__Verify_Email
@TokenId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @UserId UNIQUEIDENTIFIER;

    SELECT @UserId = UserId
    FROM Tokens WITH (UPDLOCK, ROWLOCK)
    WHERE TokenId = @TokenId AND Status = 0
    OPTION (RECOMPILE);

    IF @UserId IS NOT NULL
        BEGIN
            UPDATE Users
            SET EmailConfirmed = 1
            WHERE UserID = @UserId;

            UPDATE Tokens
            SET Status = 1
            WHERE TokenId = @TokenId;
        END;

    COMMIT TRANSACTION;
END;
