CREATE PROCEDURE sp_Institute__Find_Id
    @InstituteId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT InstituteId, UserId, Name, Type, Province, District, Url, Status
    FROM Institutes
    WHERE InstituteId = @InstituteId;
END;
