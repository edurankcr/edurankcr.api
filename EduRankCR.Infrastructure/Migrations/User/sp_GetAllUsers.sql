CREATE PROCEDURE sp_GetAllUsers
    AS
BEGIN
    SET NOCOUNT ON;

SELECT
    Id,
    Name,
    Lastname,
    Username,
    Email,
    EmailConfirmed,
    Birthdate,
    Role,
    Status,
    NewEmail,
    AvatarUrl,
    Biography,
    CreatedAt,
    UpdatedAt
FROM Users;
END;
