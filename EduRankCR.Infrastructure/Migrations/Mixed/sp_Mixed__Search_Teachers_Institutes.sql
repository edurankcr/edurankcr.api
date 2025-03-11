CREATE PROCEDURE sp_Mixed__Search_Teachers_Institutes
    @SearchTerm NVARCHAR(200) = NULL,
    @TeacherStatus TINYINT = NULL,
    @InstituteStatus TINYINT = NULL,
    @InstituteType TINYINT = NULL,
    @Province TINYINT = NULL,
    @District SMALLINT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        T.TeacherId,
        T.Name AS TeacherName,
        T.LastName,
        T.Status AS TeacherStatus,
        I.InstituteId,
        I.Name AS InstituteName,
        I.Type AS InstituteType,
        I.Province,
        I.District,
        I.Status AS InstituteStatus
    FROM Teachers T
             LEFT JOIN Institutes I ON T.InstituteId = I.InstituteId
    WHERE
        (@SearchTerm IS NULL OR T.Name LIKE '%' + @SearchTerm + '%' OR T.LastName LIKE '%' + @SearchTerm + '%' OR I.Name LIKE '%' + @SearchTerm + '%')
      AND (@TeacherStatus IS NULL OR T.Status = @TeacherStatus)
      AND (@InstituteStatus IS NULL OR I.Status = @InstituteStatus)
      AND (@InstituteType IS NULL OR I.Type = @InstituteType)
      AND (@Province IS NULL OR I.Province = @Province)
      AND (@District IS NULL OR I.District = @District)
    ORDER BY I.Name, T.Name;
END;
