CREATE PROCEDURE usp_User_Create
    @Name NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UserName NVARCHAR(50),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @BirthDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users (
        Name, LastName, UserName, Email, Password, BirthDate,
        Role, Status, CreatedAt, UpdatedAt
    )
    VALUES (@Name, @LastName, @UserName, @Email, @Password, @BirthDate,
            1, 1, GETDATE(), GETDATE()
    )
END
