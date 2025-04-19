CREATE PROCEDURE usp_User_GetByEmail
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UserId,
        Name,
        LastName,
        UserName,
        Email,
        Password,
        BirthDate,
        CreatedAt,
        EmailConfirmed
    FROM Users
    WHERE Email = @Email;
END
