CREATE PROCEDURE sp_Token__Find_Id
    @TokenId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TokenId, UserId, Status, CreatedAt, ExpiresAt
    FROM Tokens
    WHERE TokenId = @TokenId;
END;
