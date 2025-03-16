CREATE PROCEDURE sp_Teacher__Find_Id
    @TeacherId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TeacherId, UserId, InstituteId, Name, LastName, Status, CreatedAt, UpdatedAt
    FROM Teachers
    WHERE TeacherId = @TeacherId;
END;
