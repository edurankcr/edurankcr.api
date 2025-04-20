CREATE OR ALTER PROCEDURE usp_InstitutionRating_GetLatest
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 12
        r.InstitutionRatingId,
        r.InstitutionId,
        r.UserId,
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
        r.Status,

        u.UserId AS UserUserId,
        u.Name AS UserName,
        u.LastName AS UserLastName,
        u.UserName AS UserUserName,
        u.AvatarUrl AS UserAvatarUrl
    FROM Institutions_Ratings r
             LEFT JOIN Users u ON u.UserId = r.UserId
    WHERE r.Status = 1
    ORDER BY r.CreatedAt DESC;
END;
