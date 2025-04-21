CREATE OR ALTER PROCEDURE usp_InstitutionRating_GetByInstitutionIdAndUserId
    @InstitutionId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT
        InstitutionRatingId,
        InstitutionId,
        UserId,
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
        Testimony,
        CreatedAt,
        UpdatedAt,
        Status
    FROM Institutions_Ratings
    WHERE InstitutionId = @InstitutionId AND UserId = @UserId;
END
