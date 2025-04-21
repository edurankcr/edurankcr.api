CREATE OR ALTER PROCEDURE usp_InstitutionRatingAggregate_Upsert
    @InstitutionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Institutions WHERE InstitutionId = @InstitutionId)
        RETURN;

    ;WITH Aggregated AS (
        SELECT
            InstitutionId,
            AVG(CAST(Location AS FLOAT)) AS Location,
            AVG(CAST(Happiness AS FLOAT)) AS Happiness,
            AVG(CAST(Safety AS FLOAT)) AS Safety,
            AVG(CAST(Reputation AS FLOAT)) AS Reputation,
            AVG(CAST(Opportunities AS FLOAT)) AS Opportunities,
            AVG(CAST(Internet AS FLOAT)) AS Internet,
            AVG(CAST(Food AS FLOAT)) AS Food,
            AVG(CAST(Social AS FLOAT)) AS Social,
            AVG(CAST(Facilities AS FLOAT)) AS Facilities,
            AVG(CAST(Clubs AS FLOAT)) AS Clubs,
            COUNT(*) AS ReviewCount
        FROM Institutions_Ratings
        WHERE InstitutionId = @InstitutionId AND Status = 1
        GROUP BY InstitutionId
    )
    MERGE Institutions_Ratings_Aggregate AS target
    USING Aggregated AS source
    ON target.InstitutionId = source.InstitutionId
    WHEN MATCHED THEN
        UPDATE SET
            Location = source.Location,
            Happiness = source.Happiness,
            Safety = source.Safety,
            Reputation = source.Reputation,
            Opportunities = source.Opportunities,
            Internet = source.Internet,
            Food = source.Food,
            Social = source.Social,
            Facilities = source.Facilities,
            Clubs = source.Clubs,
            OverallAverage = (
                source.Location +
                source.Happiness +
                source.Safety +
                source.Reputation +
                source.Opportunities +
                source.Internet +
                source.Food +
                source.Social +
                source.Facilities +
                source.Clubs
            ) / 10,
            ReviewCount = source.ReviewCount
    WHEN NOT MATCHED THEN
        INSERT (
            InstitutionId,
            Location,
            Happiness,
            Safety,
            Reputation,
            Opportunities,
            Internet,
            Food,
            Social,
            Facilities,
            Clubs,
            OverallAverage,
            ReviewCount
        )
        VALUES (
            source.InstitutionId,
            source.Location,
            source.Happiness,
            source.Safety,
            source.Reputation,
            source.Opportunities,
            source.Internet,
            source.Food,
            source.Social,
            source.Facilities,
            source.Clubs,
            (
                source.Location +
                source.Happiness +
                source.Safety +
                source.Reputation +
                source.Opportunities +
                source.Internet +
                source.Food +
                source.Social +
                source.Facilities +
                source.Clubs
            ) / 10,
            source.ReviewCount
        );
END;
