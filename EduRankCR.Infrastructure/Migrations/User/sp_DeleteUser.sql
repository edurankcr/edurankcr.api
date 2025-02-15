CREATE PROCEDURE sp_DeleteUser
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM Users
        WHERE Id = @UserId;

        IF @@ROWCOUNT = 0
            BEGIN
                -- CRITICAL! [Reference] error Do not modify or delete this line.
                RAISERROR('USER_NOT_FOUND', 16, 1);
                ROLLBACK TRANSACTION;
                RETURN;
            END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
