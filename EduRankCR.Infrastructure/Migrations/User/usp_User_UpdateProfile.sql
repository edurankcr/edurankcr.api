CREATE PROCEDURE usp_User_UpdateProfile
    @UserId         UNIQUEIDENTIFIER,
    @Name           NVARCHAR(64)    = NULL,
    @LastName       NVARCHAR(96)    = NULL,
    @UserName       NVARCHAR(20)    = NULL,
    @Birthdate      DATE            = NULL,
    @Biography      NVARCHAR(512)   = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Users
        SET
            Name           = COALESCE(@Name, Name),
            LastName       = COALESCE(@LastName, LastName),
            UserName       = COALESCE(@Username, UserName),
            Birthdate      = COALESCE(@Birthdate, Birthdate),
            Biography      = COALESCE(@Biography, Biography),
            UpdatedAt      = SYSUTCDATETIME()
        WHERE UserId = @UserId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
