CREATE PROCEDURE sp_Institute__Details
@InstituteId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        I.InstituteId,
        I.UserId,
        I.Name,
        I.Type,
        I.Province,
        I.Url,
        I.Status
    FROM Institutes I
    WHERE I.InstituteId = @InstituteId;

    SELECT
        S.InstituteId,
        S.TotalReviews,
        S.TotalAverageScore,
        S.Reputation,
        S.Opportunities,
        S.Happiness,
        S.Location,
        S.Facilities,
        S.Social,
        S.Clubs,
        S.Internet,
        S.Security,
        S.Food,
        S.UpdatedAt
    FROM Institutes_Reviews_Summaries S
    WHERE S.InstituteId = @InstituteId;

    SELECT TOP 12
        R.ReviewId,
        R.UserId,
        R.InstituteId,
        R.Reputation,
        R.Opportunities,
        R.Happiness,
        R.Location,
        R.Facilities,
        R.Social,
        R.Clubs,
        R.Internet,
        R.Security,
        R.Food,
        R.ExperienceText,
        R.Status,
        R.CreatedAt,
        R.UpdatedAt
    FROM Institutes_Reviews R
    WHERE R.InstituteId = @InstituteId
    AND R.Status = 1
    ORDER BY R.CreatedAt DESC;
END;
