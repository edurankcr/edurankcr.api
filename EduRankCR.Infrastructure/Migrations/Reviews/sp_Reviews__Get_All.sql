CREATE PROCEDURE sp_Reviews__Get_All
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 6
        t.TeacherId,
        t.Name AS TeacherName,
        t.LastName AS TeacherLastName,

        tr.ReviewId,
        tr.FreeCourse,
        tr.CourseCode,
        tr.CourseMode,
        tr.ProfessorRating,
        tr.DifficultyRating,
        tr.WouldTakeAgain,
        tr.MandatoryAttendance,
        tr.GradeReceived,
        tr.ExperienceText,
        tr.CreatedAt,
        tr.UpdatedAt,

        u.Name AS UserFirstName,
        u.LastName AS UserLastName,
        u.UserName,
        u.AvatarUrl
    FROM Teachers_Reviews tr
             INNER JOIN Teachers t ON tr.TeacherId = t.TeacherId
             INNER JOIN [Users] u ON tr.UserId = u.UserId
    ORDER BY tr.CreatedAt DESC;

    SELECT TOP 6
        i.InstituteId,
        i.Name AS InstituteName,
        i.Type AS InstituteType,

        ir.ReviewId,
        ir.Reputation,
        ir.Opportunities,
        ir.Happiness,
        ir.Location,
        ir.Facilities,
        ir.Social,
        ir.Clubs,
        ir.Internet,
        ir.Security,
        ir.Food,
        ir.ExperienceText,
        ir.CreatedAt,
        ir.UpdatedAt,

        u.Name AS UserFirstName,
        u.LastName AS UserLastName,
        u.UserName,
        u.AvatarUrl
    FROM Institutes_Reviews ir
             INNER JOIN Institutes i ON ir.InstituteId = i.InstituteId
             INNER JOIN [Users] u ON ir.UserId = u.UserId
    ORDER BY ir.CreatedAt DESC;
END;
