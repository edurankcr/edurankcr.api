CREATE OR ALTER PROCEDURE usp_Search_ByName
    @Name NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#Results') IS NOT NULL DROP TABLE #Results;

    CREATE TABLE #Results (
        Type NVARCHAR(15),
        Id UNIQUEIDENTIFIER,
        Name NVARCHAR(255),
        LastName NVARCHAR(255),
        Province TINYINT NULL,
        InstitutionType TINYINT NULL,
        CreatedAt DATETIME2,
        UpdatedAt DATETIME2,
        OverallAverage FLOAT,
        ReviewCount INT
    );

    INSERT INTO #Results
    SELECT
        'Institution',
        i.InstitutionId,
        i.Name,
        NULL,
        i.Province,
        i.Type,
        i.CreatedAt,
        i.UpdatedAt,
        ISNULL(ira.OverallAverage, 0),
        ISNULL(ira.ReviewCount, 0)
    FROM Institutions i
    LEFT JOIN Institutions_Ratings_Aggregate ira ON i.InstitutionId = ira.InstitutionId
    WHERE i.Name LIKE '%' + @Name + '%'

    INSERT INTO #Results
    SELECT
        'Teacher',
        t.TeacherId,
        t.Name,
        t.LastName,
        NULL,
        NULL,
        t.CreatedAt,
        t.UpdatedAt,
        ISNULL(tra.OverallAverage, 0),
        ISNULL(tra.ReviewCount, 0)
    FROM Teachers t
    LEFT JOIN Teachers_Ratings_Aggregates tra ON t.TeacherId = tra.TeacherId
    WHERE t.Name LIKE '%' + @Name + '%' OR t.LastName LIKE '%' + @Name + '%'

    SELECT
        (SELECT COUNT(*) FROM #Results) AS AllCount,
        (SELECT COUNT(*) FROM #Results WHERE Type = 'Institution') AS AllInstitutionCount,
        (SELECT COUNT(*) FROM #Results WHERE Type = 'Teacher') AS AllTeacherCount;

    SELECT TOP 12 *
    FROM #Results
    ORDER BY ReviewCount DESC;
END;
