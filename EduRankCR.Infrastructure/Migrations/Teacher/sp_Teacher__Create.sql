CREATE PROCEDURE sp_Teacher__Create
    @UserId UNIQUEIDENTIFIER,
    @InstituteId UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert new teacher record
    INSERT INTO Teachers (TeacherId, UserId, InstituteId, Name, LastName, Status, CreatedAt, UpdatedAt)
    VALUES (NEWID(), @UserId, @InstituteId, @Name, @LastName, @Status, GETDATE(), GETDATE());
END
