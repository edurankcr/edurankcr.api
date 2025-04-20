CREATE PROCEDURE usp_Teacher_GetById
    @TeacherId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        TeacherId,
        UserId,
        Name,
        LastName,
        Biography,
        AvatarUrl,
        CreatedAt,
        UpdatedAt,
        Status
    FROM Teachers
    WHERE TeacherId = @TeacherId;
END;
