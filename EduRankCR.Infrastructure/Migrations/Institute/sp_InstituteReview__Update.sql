CREATE PROCEDURE sp_InstituteReview__Update
    @ReviewId   UNIQUEIDENTIFIER,
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
    @Status TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE InstitutesReviews
        SET
            Reputation          = COALESCE(@Reputation, Reputation),
            Opportunities       = COALESCE(@Opportunities, Opportunities),
            Happiness           = COALESCE(@Happiness, Happiness),
            Location            = COALESCE(@Location, Location),
            Facilities          = COALESCE(@Facilities, Facilities),
            Social              = COALESCE(@Social, Social),
            Clubs               = COALESCE(@Clubs, Clubs),
            Internet            = COALESCE(@Internet, Internet),
            Security            = COALESCE(@Security, Security),
            Food                = COALESCE(@Food, Food),
            ExperienceText      = COALESCE(@ExperienceText, ExperienceText),
            Status              = COALESCE(@Status, Status),
            UpdatedAt           = SYSUTCDATETIME()
        WHERE ReviewId = @ReviewId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
