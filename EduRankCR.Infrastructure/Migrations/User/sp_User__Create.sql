CREATE PROCEDURE sp_User__Create
    @Name NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UserName NVARCHAR(50),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @BirthDate DATE,
    @UserId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Start transaction
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Generate a new UserId
        SET @UserId = NEWID();

        -- Insert user
        INSERT INTO Users (UserId, Name, LastName, UserName, Email, Password, BirthDate, Role, Status, CreatedAt, UpdatedAt)
        VALUES (@UserId, @Name, @LastName, @UserName, @Email, @Password, @BirthDate, 0, 0, GETDATE(), GETDATE());

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback if error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Return error message
        THROW;
    END CATCH;
END;
