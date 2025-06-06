﻿CREATE PROCEDURE usp_User_UpdateEmail
    @UserId UNIQUEIDENTIFIER,
    @NewEmail NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET EmailConfirmed = 1,
        Email = @NewEmail,
        UpdatedAt = GETDATE()
    WHERE UserId = @UserId;
END
