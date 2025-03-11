CREATE PROCEDURE sp_User__Find_Identifier
    @Identifier NVARCHAR(255)
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
        NewEmail,
        CreatedAt,
        UpdatedAt
    FROM Users
    WHERE UserName = @Identifier OR Email = @Identifier;
END;
