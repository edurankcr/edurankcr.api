CREATE PROCEDURE sp_Token__Verify_Change_Email
    @TokenId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId UNIQUEIDENTIFIER;
    DECLARE @NewEmail NVARCHAR(255);

    SELECT @UserId = Users.UserId, @NewEmail = Users.NewEmail
    FROM Tokens
             INNER JOIN Users ON Tokens.UserId = Users.UserId
    WHERE Tokens.TokenId = @TokenId
      AND Tokens.Status = 0;

    IF @UserId IS NOT NULL AND @NewEmail IS NOT NULL
        BEGIN
            UPDATE Users
            SET Email = @NewEmail,
                NewEmail = NULL,
                EmailConfirmed = 1
            WHERE UserId = @UserId;

            UPDATE Tokens
            SET Status = 1
            WHERE TokenId = @TokenId;
        END

    SELECT @@ROWCOUNT AS RowsAffected;
END;
