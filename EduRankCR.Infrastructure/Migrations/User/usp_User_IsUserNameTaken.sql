CREATE PROCEDURE usp_User_IsUserNameTaken
    @UserName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 1
    FROM Users
    WHERE UserName = @UserName;
END
