CREATE PROCEDURE usp_User_IdentifierExists
    @Email NVARCHAR(255),
    @UserName NVARCHAR(50),
    @ExistingIdentifier NVARCHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
        BEGIN
            SET @ExistingIdentifier = 'Email';
            RETURN;
        END

    IF EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName)
        BEGIN
            SET @ExistingIdentifier = 'UserName';
            RETURN;
        END

    SET @ExistingIdentifier = NULL;
END
