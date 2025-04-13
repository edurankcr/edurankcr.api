CREATE PROCEDURE sp_Institute__Create
    @InstituteId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(200),
    @Type TINYINT = 0,
    @Province TINYINT = 0,
    @Url NVARCHAR(350) = NULL,
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Institutes (InstituteId, UserId, Name, Type, Province, Url, Status, CreatedAt, UpdatedAt)
        VALUES (@InstituteId, @UserId, @Name, @Type, @Province, @Url, @Status, GETDATE(), GETDATE());

        INSERT INTO Institutes_Reviews_Summaries (InstituteId, TotalReviews, TotalAverageScore, Reputation, Opportunities, Happiness, Location, Facilities, Social, Clubs, Internet, Security, Food, UpdatedAt)
        VALUES (@InstituteId, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, GETDATE());

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
