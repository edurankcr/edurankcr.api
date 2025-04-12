CREATE PROCEDURE sp_Institute__Get_Details
    @InstituteId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        InstituteId,
        Name,
        Type,
        Province,
        Url,
        Status,
        CreatedAt,
        UpdatedAt
    FROM Institutes
    WHERE InstituteId = @InstituteId;
END;
