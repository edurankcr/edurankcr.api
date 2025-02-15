CREATE PROCEDURE sp_CreateUser
    @Name NVARCHAR(32),
    @Lastname NVARCHAR(64),
    @Username NVARCHAR(18),
    @Email NVARCHAR(255),
    @EmailConfirmed BIT,
    @Role TINYINT = 0,
    @Birthdate DATE,
    @Password NVARCHAR(255),
    @AvatarUrl NVARCHAR(255) = NULL,
    @Biography NVARCHAR(512) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserId UNIQUEIDENTIFIER = NEWID();
    DECLARE @CurrentUtc DATETIME2(3) = SYSUTCDATETIME();

BEGIN TRY
BEGIN TRANSACTION;

INSERT INTO Users (Id, Name, Lastname, Username, Email, EmailConfirmed, Birthdate, Password, Role, Status, AvatarUrl, Biography, CreatedAt, UpdatedAt)
VALUES (@UserId, @Name, @Lastname, @Username, @Email, @EmailConfirmed, @Birthdate, @Password, @Role, 0, @AvatarUrl, @Biography, @CurrentUtc, @CurrentUtc);

COMMIT TRANSACTION;

SELECT @UserId AS UserId;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
        THROW;
END CATCH;
END;