CREATE PROCEDURE sp_Reviews__RecalculateAllInstituteSummaries
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Summary AS (
        SELECT
            R.InstituteId,
            COUNT(*) AS TotalReviews,
            AVG(R.Reputation) AS AvgReputation,
            AVG(R.Opportunities) AS AvgOpportunities,
            AVG(R.Happiness) AS AvgHappiness,
            AVG(R.Location) AS AvgLocation,
            AVG(R.Facilities) AS AvgFacilities,
            AVG(R.Social) AS AvgSocial,
            AVG(R.Clubs) AS AvgClubs,
            AVG(R.Internet) AS AvgInternet,
            AVG(R.Security) AS AvgSecurity,
            AVG(R.Food) AS AvgFood
        FROM Institutes_Reviews R
        GROUP BY R.InstituteId
    )
     UPDATE IRS
     SET
         TotalReviews = S.TotalReviews,
         Reputation = S.AvgReputation,
         Opportunities = S.AvgOpportunities,
         Happiness = S.AvgHappiness,
         Location = S.AvgLocation,
         Facilities = S.AvgFacilities,
         Social = S.AvgSocial,
         Clubs = S.AvgClubs,
         Internet = S.AvgInternet,
         Security = S.AvgSecurity,
         Food = S.AvgFood,
         TotalAverageScore = (
             (S.AvgReputation + S.AvgOpportunities + S.AvgHappiness + S.AvgLocation + S.AvgFacilities +
              S.AvgSocial + S.AvgClubs + S.AvgInternet + S.AvgSecurity + S.AvgFood) / 10.0
             ),
         UpdatedAt = GETDATE()
     FROM Institutes_Reviews_Summaries IRS
              JOIN Summary S ON S.InstituteId = IRS.InstituteId;
END;
