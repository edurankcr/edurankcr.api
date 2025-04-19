CREATE PROCEDURE usp_User_IsEmailTaken
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 1
    FROM Users
    WHERE Email = @Email;
END
