CREATE PROCEDURE usp_InstitutionRating_GetByInstitutionId
    @InstitutionId UNIQUEIDENTIFIER,
    @Quantity INT = 12
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@Quantity)
        r.InstitutionRatingId,
        r.InstitutionId,
        r.UserId AS UserUserId,
        u.Name AS UserName,
        u.LastName AS UserLastName,
        u.UserName AS UserUserName,
        u.AvatarUrl as UserAvatarUrl,
        r.Location,
        r.Happiness,
        r.Safety,
        r.Reputation,
        r.Opportunities,
        r.Internet,
        r.Food,
        r.Social,
        r.Facilities,
        r.Clubs,
        r.Testimony,
        r.CreatedAt,
        r.UpdatedAt,
        r.Status
    FROM Institutions_Ratings r
             INNER JOIN Users u ON r.UserId = u.UserId
    WHERE r.InstitutionId = @InstitutionId
    ORDER BY r.CreatedAt DESC;
END
