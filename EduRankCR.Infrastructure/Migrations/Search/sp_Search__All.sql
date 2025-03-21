﻿CREATE PROCEDURE sp_Search__All
    @Name NVARCHAR(100),
    @Type NVARCHAR(20) = NULL,
    @InstituteId UNIQUEIDENTIFIER = NULL,
    @TypeFilter TINYINT = NULL,
    @Province TINYINT = NULL,
    @District SMALLINT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Type = 'teacher' OR @Type = 'all' OR @Type IS NULL
        BEGIN
            SELECT
                t.TeacherId,
                t.Name,
                t.LastName,
                i.InstituteId,
                i.Name AS InstituteName
            FROM Teachers t
                     LEFT JOIN Institutes i ON t.InstituteId = i.InstituteId
            WHERE
                (@Name IS NULL OR t.Name LIKE '%' + @Name + '%' OR t.LastName LIKE '%' + @Name + '%')
              AND (@InstituteId IS NULL OR t.InstituteId = @InstituteId);
        END
    ELSE
        BEGIN
            SELECT
                CAST(NULL AS UNIQUEIDENTIFIER) AS TeacherId,
                CAST(NULL AS NVARCHAR(100)) AS Name,
                CAST(NULL AS NVARCHAR(100)) AS LastName,
                CAST(NULL AS UNIQUEIDENTIFIER) AS InstituteId,
                CAST(NULL AS NVARCHAR(100)) AS InstituteName
            WHERE 1 = 0;
        END

    IF @Type = 'institute' OR @Type = 'all' OR @Type IS NULL
        BEGIN
            SELECT
                i.InstituteId,
                i.Name,
                i.Type,
                i.Province,
                i.District,
                i.Url
            FROM Institutes i
            WHERE
                (@Name IS NULL OR i.Name LIKE '%' + @Name + '%')
              AND (@TypeFilter IS NULL OR i.Type = @TypeFilter)
              AND (@Province IS NULL OR i.Province = @Province)
              AND (@District IS NULL OR i.District = @District);
        END
    ELSE
        BEGIN
            SELECT
                CAST(NULL AS UNIQUEIDENTIFIER) AS InstituteId,
                CAST(NULL AS NVARCHAR(100)) AS Name,
                CAST(NULL AS TINYINT) AS Type,
                CAST(NULL AS TINYINT) AS Province,
                CAST(NULL AS SMALLINT) AS District,
                CAST(NULL AS NVARCHAR(255)) AS Url
            WHERE 1 = 0;
        END
END;
