CREATE PROCEDURE sp_Token__Verify_Password
    @TokenId UNIQUEIDENTIFIER,
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId UNIQUEIDENTIFIER;

    SELECT @UserId = UserId
    FROM Tokens
    WHERE TokenId = @TokenId
        AND Status = 0;

    IF @UserId IS NOT NULL
        BEGIN
            UPDATE Users
            SET Password = @Password
            WHERE UserID = @UserId;

            UPDATE Tokens
            SET Status = 1
            WHERE TokenId = @TokenId;
        END

    SELECT @@ROWCOUNT AS RowsAffected;
END;
