CREATE OR ALTER PROCEDURE usp_TeacherRating_GetLatest
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 6
        r.TeacherRatingId,
        r.TeacherId,
        r.UserId,
        r.Clarity,
        r.Knowledge,
        r.Respect,
        r.Fairness,
        r.Punctuality,
        r.Motivation,
        r.WouldTakeAgain,
        r.Testimony,
        r.CreatedAt,
        r.UpdatedAt,
        r.Status,

        u.UserId AS UserUserId,
        u.Name AS UserName,
        u.LastName AS UserLastName,
        u.UserName AS UserUserName,
        u.AvatarUrl AS UserAvatarUrl
    FROM Teachers_Ratings r
             LEFT JOIN Users u ON u.UserId = r.UserId
    WHERE r.Status = 1
    ORDER BY r.CreatedAt DESC;
END;
