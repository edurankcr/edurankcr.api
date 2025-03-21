CREATE PROCEDURE sp_Institute__Create
    @InstituteId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @Type TINYINT = 0,
    @Province TINYINT = 0,
    @District SMALLINT = 0,
    @Url NVARCHAR(350) = NULL,
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Institutes (InstituteId, UserId, Name, Type, Province, District, Url, Status, CreatedAt, UpdatedAt)
    VALUES (@InstituteId, @UserId, @Name, @Type, @Province, @District, @Url, @Status, GETDATE(), GETDATE());
END;
