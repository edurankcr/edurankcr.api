CREATE PROCEDURE usp_User_GetByIdentifier
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
        EmailConfirmed,
        NewEmail,
        Role,
        Status,
        AvatarUrl,
        Biography,
        BirthDate,
        Password,
        PasswordChangedAt,
        CreatedAt,
        UpdatedAt
    FROM Users
    WHERE Email = @Identifier OR UserName = @Identifier;
END
