CREATE PROCEDURE usp_User_GetById
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT
        UserId,
        Name,
        LastName,
        UserName,
        Email,
        EmailConfirmed,
        NewEmail,
        Password,
        BirthDate,
        CreatedAt
    FROM Users
    WHERE UserId = @UserId;
END
