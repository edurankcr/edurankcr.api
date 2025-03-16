CREATE PROCEDURE sp_InstituteReview__Find_InstituteId
    @UserId UNIQUEIDENTIFIER,
    @InstituteId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ReviewId, UserId, InstituteId, Reputation, Opportunities, Happiness, Location, Facilities, Social, Clubs, Internet,
           Security, Food, ExperienceText, Status, CreatedAt, UpdatedAt
    FROM InstitutesReviews
    WHERE UserId = @UserId AND InstituteId = @InstituteId;
END;
