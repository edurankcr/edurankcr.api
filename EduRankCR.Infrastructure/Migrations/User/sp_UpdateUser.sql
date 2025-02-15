-- noinspection SqlUnreachableForFile

CREATE PROCEDURE sp_UpdateUser
    @UserId         UNIQUEIDENTIFIER,
    @Name           NVARCHAR(32)    = NULL,
    @LastName       NVARCHAR(64)    = NULL,
    @Username       NVARCHAR(18)    = NULL,
    @Email          NVARCHAR(255)   = NULL,
    @EmailConfirmed BIT             = NULL,
    @Birthdate      DATE            = NULL,
    @Role           TINYINT         = NULL,
    @Status         TINYINT         = NULL,
    @AvatarUrl      NVARCHAR(255)   = NULL,
    @Biography      NVARCHAR(512)   = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Birthdate IS NOT NULL AND @Birthdate < DATEADD(YEAR, -100, GETDATE())
        SET @Birthdate = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Users WHERE Id = @UserId)
            BEGIN
                -- CRITICAL! [Reference] error Do not modify or delete this line.
                RAISERROR('USER_NOT_FOUND', 16, 1);
                ROLLBACK TRANSACTION;
                RETURN;
            END;

        UPDATE Users
        SET
            Name           = COALESCE(@Name, Name),
            LastName       = COALESCE(@LastName, LastName),
            Username       = COALESCE(@Username, Username),
            Email          = COALESCE(@Email, Email),
            EmailConfirmed = COALESCE(@EmailConfirmed, EmailConfirmed),
            Birthdate      = COALESCE(@Birthdate, Birthdate),
            Role           = COALESCE(@Role, Role),
            Status         = COALESCE(@Status, Status),
            AvatarUrl      = COALESCE(@AvatarUrl, AvatarUrl),
            Biography      = COALESCE(@Biography, Biography),
            UpdatedAt      = SYSUTCDATETIME()
        WHERE Id = @UserId;

        IF @@ROWCOUNT = 0
            BEGIN
                RAISERROR('No changes were applied.', 16, 1);
                ROLLBACK TRANSACTION;
                RETURN;
            END;

        COMMIT TRANSACTION;

        SELECT @UserId AS UserId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
