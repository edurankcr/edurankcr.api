CREATE PROCEDURE usp_User_GetProfileById
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UserId,
        Name,
        LastName,
        UserName,
        Email,
        EmailConfirmed,
        NewEmail,
        Role,
        Status,
        AvatarUrl,
        Biography,
        BirthDate,
        PasswordChangedAt,
        CreatedAt,
        UpdatedAt
    FROM Users
    WHERE UserId = @UserId;
END
