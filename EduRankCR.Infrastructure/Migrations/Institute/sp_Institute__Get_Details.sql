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
        District,
        Url,
        Status,
        CreatedAt,
        UpdatedAt
    FROM Institutes
    WHERE InstituteId = @InstituteId;

    SELECT
        T.TeacherId,
        T.Name AS TeacherName,
        T.LastName,
        T.Status AS TeacherStatus
    FROM Teachers T
    WHERE T.InstituteId = @InstituteId
    ORDER BY T.Name, T.LastName;
END;
