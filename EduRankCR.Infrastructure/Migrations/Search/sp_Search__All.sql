CREATE PROCEDURE sp_Search__All
    @Name NVARCHAR(100),
    @Type NVARCHAR(20) = NULL,
    @TypeFilter TINYINT = NULL,
    @Province TINYINT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Type IS NULL OR @Type IN ('teacher', 'all')
        BEGIN
            SELECT
                t.TeacherId,
                t.Name,
                t.LastName,
                (t.Name + ' ' + t.LastName) AS FullName,
                t.CreatedAt,
                t.UpdatedAt
            FROM Teachers t
            WHERE
                t.Status = 1
              AND (@Name IS NULL OR t.Name LIKE '%' + @Name + '%' OR t.LastName LIKE '%' + @Name + '%');
        END

    IF @Type IS NULL OR @Type IN ('institute', 'all')
        BEGIN
            SELECT
                i.InstituteId,
                i.Name,
                i.Type,
                i.Province,
                i.Url,
                i.CreatedAt,
                i.UpdatedAt
            FROM Institutes i
            WHERE
                i.Status = 1
              AND (@Name IS NULL OR i.Name LIKE '%' + @Name + '%')
              AND (@TypeFilter IS NULL OR i.Type = @TypeFilter)
              AND (@Province IS NULL OR i.Province = @Province);
        END
END;
