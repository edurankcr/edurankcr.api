CREATE OR ALTER PROCEDURE usp_InstitutionRating_Update
    @InstitutionRatingId UNIQUEIDENTIFIER,
    @UserId               UNIQUEIDENTIFIER,
    @Location             TINYINT       = NULL,
    @Happiness            TINYINT       = NULL,
    @Safety               TINYINT       = NULL,
    @Reputation           TINYINT       = NULL,
    @Opportunities        TINYINT       = NULL,
    @Internet             TINYINT       = NULL,
    @Food                 TINYINT       = NULL,
    @Social               TINYINT       = NULL,
    @Facilities           TINYINT       = NULL,
    @Clubs                TINYINT       = NULL,
    @Testimony            NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Institutions_Ratings
        SET
            Location      = COALESCE(@Location, Location),
            Happiness     = COALESCE(@Happiness, Happiness),
            Safety        = COALESCE(@Safety, Safety),
            Reputation    = COALESCE(@Reputation, Reputation),
            Opportunities = COALESCE(@Opportunities, Opportunities),
            Internet      = COALESCE(@Internet, Internet),
            Food          = COALESCE(@Food, Food),
            Social        = COALESCE(@Social, Social),
            Facilities    = COALESCE(@Facilities, Facilities),
            Clubs         = COALESCE(@Clubs, Clubs),
            Testimony     = COALESCE(@Testimony, Testimony),
            UpdatedAt     = SYSUTCDATETIME()
        WHERE InstitutionRatingId = @InstitutionRatingId AND UserId = @UserId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
