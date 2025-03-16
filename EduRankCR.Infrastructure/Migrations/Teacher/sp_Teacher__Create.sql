CREATE PROCEDURE sp_Teacher__Create
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TeacherId UNIQUEIDENTIFIER = NEWID();

    INSERT INTO Teachers (TeacherId, UserId, Name, LastName, Status, CreatedAt, UpdatedAt)
    VALUES (@TeacherId, @UserId, @Name, @LastName, @Status, GETDATE(), GETDATE());
END;
