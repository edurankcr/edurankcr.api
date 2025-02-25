CREATE PROCEDURE sp_Token__Create
    @TokenId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Status TINYINT,
    @CreatedAt DATETIME2(3),
    @ExpiresAt DATETIME2(3)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Tokens
    SET Status = 3
    WHERE UserId = @UserId AND Status = 0;

    INSERT INTO Tokens (TokenId, UserId, Status, CreatedAt, ExpiresAt)
    VALUES (@TokenId, @UserId, @Status, @CreatedAt, @ExpiresAt);
END;
