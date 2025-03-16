CREATE PROCEDURE sp_InstituteReview__Create
(
    @UserId UNIQUEIDENTIFIER,
    @InstituteId UNIQUEIDENTIFIER,
    @Reputation  DECIMAL(2, 1),
    @Opportunities DECIMAL(2, 1),
    @Happiness DECIMAL(2, 1),
    @Location DECIMAL(2, 1),
    @Facilities DECIMAL(2, 1),
    @Social DECIMAL(2, 1),
    @Clubs DECIMAL(2, 1),
    @Internet DECIMAL(2, 1),
    @Security DECIMAL(2, 1),
    @Food DECIMAL(2, 1),
    @ExperienceText NVARCHAR(510),
    @Status TINYINT = 0,
    @CreatedAt DATETIME2 = NULL,
    @UpdatedAt DATETIME2 = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @CreatedAt IS NULL SET @CreatedAt = GETDATE();
    IF @UpdatedAt IS NULL SET @UpdatedAt = GETDATE();

    INSERT INTO InstitutesReviews (
        ReviewId, UserId, InstituteId, Reputation, Opportunities, Happiness, Location, Facilities, Social, Clubs,
        Internet, Security, Food, ExperienceText, Status, CreatedAt, UpdatedAt
    )
    VALUES (
               NEWID(), @UserId, @InstituteId, @Reputation, @Opportunities, @Happiness, @Location, @Facilities,
                @Social, @Clubs, @Internet, @Security, @Food, @ExperienceText, @Status, @CreatedAt, @UpdatedAt
           );
END;
