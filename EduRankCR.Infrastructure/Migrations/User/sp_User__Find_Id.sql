CREATE PROCEDURE sp_User__Find_Id
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
        BirthDate,
        Password,
        Role,
        Status,
        AvatarUrl,
        Biography,
        EmailConfirmed,
        CreatedAt,
        UpdatedAt
    FROM Users
    WHERE UserId = @UserId;
END;
