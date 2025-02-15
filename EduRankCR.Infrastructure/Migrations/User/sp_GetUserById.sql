CREATE PROCEDURE sp_GetUserById
@UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
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
        FROM Users
        WHERE Id = @UserId;

        IF @@ROWCOUNT = 0
            BEGIN
                -- CRITICAL! [Reference] error Do not modify or delete this line.
                RAISERROR('USER_NOT_FOUND', 16, 1);
            END;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH;
END;
