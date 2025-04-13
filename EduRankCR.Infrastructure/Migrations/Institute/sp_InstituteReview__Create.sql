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

    DECLARE @NewReviewId UNIQUEIDENTIFIER = NEWID();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Institutes_Reviews (
            ReviewId, UserId, InstituteId, Reputation, Opportunities, Happiness, Location, Facilities, Social, Clubs,
            Internet, Security, Food, ExperienceText, Status, CreatedAt, UpdatedAt
        )
        VALUES (
                   @NewReviewId, @UserId, @InstituteId, @Reputation, @Opportunities, @Happiness, @Location, @Facilities,
                   @Social, @Clubs, @Internet, @Security, @Food, @ExperienceText, @Status, @CreatedAt, @UpdatedAt
               );

        UPDATE IRS
        SET
            TotalReviews     = TotalReviews + 1,
            Reputation       = ((Reputation * TotalReviews) + @Reputation) / (TotalReviews + 1),
            Opportunities    = ((Opportunities * TotalReviews) + @Opportunities) / (TotalReviews + 1),
            Happiness        = ((Happiness * TotalReviews) + @Happiness) / (TotalReviews + 1),
            Location         = ((Location * TotalReviews) + @Location) / (TotalReviews + 1),
            Facilities       = ((Facilities * TotalReviews) + @Facilities) / (TotalReviews + 1),
            Social           = ((Social * TotalReviews) + @Social) / (TotalReviews + 1),
            Clubs            = ((Clubs * TotalReviews) + @Clubs) / (TotalReviews + 1),
            Internet         = ((Internet * TotalReviews) + @Internet) / (TotalReviews + 1),
            Security         = ((Security * TotalReviews) + @Security) / (TotalReviews + 1),
            Food             = ((Food * TotalReviews) + @Food) / (TotalReviews + 1),
            TotalAverageScore = (
                (
                    (Reputation + Opportunities + Happiness + Location + Facilities +
                     Social + Clubs + Internet + Security + Food) / 10.0
                    )
                ),
            UpdatedAt        = GETDATE()
        FROM Institutes_Reviews_Summaries IRS
        WHERE IRS.InstituteId = @InstituteId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
