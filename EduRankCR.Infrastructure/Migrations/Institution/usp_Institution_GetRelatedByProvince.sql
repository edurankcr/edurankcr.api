CREATE OR ALTER PROCEDURE usp_Institution_GetRelatedByProvince
    @InstitutionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Province TINYINT;
    DECLARE @ReviewCount INT;

    SELECT
    @Province = i.Province,
    @ReviewCount = ira.ReviewCount
FROM Institutions i
    INNER JOIN Institutions_Ratings_Aggregate ira ON i.InstitutionId = ira.InstitutionId
WHERE i.InstitutionId = @InstitutionId;

    SELECT TOP 6
        i.InstitutionId,
        i.Name,
        i.Description,
        i.Province,
        i.Type,
        i.WebsiteUrl,
        ira.OverallAverage,
        ira.ReviewCount
    FROM Institutions i
             INNER JOIN Institutions_Ratings_Aggregate ira ON i.InstitutionId = ira.InstitutionId
    WHERE
        i.Province = @Province
      AND i.InstitutionId != @InstitutionId
      AND i.Status = 1
    ORDER BY ABS(ira.ReviewCount - @ReviewCount);
END;
