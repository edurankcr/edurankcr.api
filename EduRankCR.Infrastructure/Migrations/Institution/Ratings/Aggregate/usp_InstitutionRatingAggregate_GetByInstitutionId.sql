CREATE PROCEDURE usp_InstitutionRatingAggregate_GetByInstitutionId
    @InstitutionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        InstitutionId,
        Location,
        Happiness,
        Safety,
        Reputation,
        Opportunities,
        Internet,
        Food,
        Social,
        Facilities,
        Clubs,
        OverallAverage,
        ReviewCount
    FROM Institutions_Ratings_Aggregate
    WHERE InstitutionId = @InstitutionId;
END
