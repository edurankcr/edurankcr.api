CREATE PROCEDURE sp_CreateUser
    @Name           NVARCHAR(32),
    @Lastname       NVARCHAR(64),
    @Username       NVARCHAR(18),
    @Email          NVARCHAR(255),
    @EmailConfirmed BIT,
    @Role           TINYINT        = 0,
    @Birthdate      DATE,
    @Password       NVARCHAR(255),
    @AvatarUrl      NVARCHAR(255)  = NULL,
    @Biography      NVARCHAR(512)  = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId     UNIQUEIDENTIFIER = NEWID();
    DECLARE @CurrentUtc DATETIME2(3) = SYSUTCDATETIME();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Users (
            Id, Name, Lastname, Username, Email, EmailConfirmed, Birthdate, Password,
            Role, Status, AvatarUrl, Biography, CreatedAt, UpdatedAt
        )
        VALUES (
                   @UserId, @Name, @Lastname, @Username, @Email, @EmailConfirmed, @Birthdate, @Password,
                   @Role, 0, @AvatarUrl, @Biography, @CurrentUtc, @CurrentUtc
               );

        COMMIT TRANSACTION;

        SELECT @UserId AS Id, @Name AS Name, @Lastname AS Lastname, @Username AS Username, @Email AS Email,
               @EmailConfirmed AS EmailConfirmed, @Birthdate AS Birthdate, @Role AS Role, 0 AS Status,
               null AS NewEmail, @AvatarUrl AS AvatarUrl, @Biography AS Biography, @CurrentUtc AS CreatedAt,
               @CurrentUtc AS UpdatedAt;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
