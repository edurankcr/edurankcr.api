CREATE OR ALTER PROCEDURE usp_InstitutionRating_Create
    @InstitutionId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Location TINYINT,
    @Happiness TINYINT,
    @Safety TINYINT,
    @Reputation TINYINT,
    @Opportunities TINYINT,
    @Internet TINYINT,
    @Food TINYINT,
    @Social TINYINT,
    @Facilities TINYINT,
    @Clubs TINYINT,
    @Testimony NVARCHAR(MAX),
    @CreatedAt DATETIME2,
    @Status TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Institutions_Ratings (
        InstitutionId,
        UserId,
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
        Testimony,
        CreatedAt,
        Status
    )
    VALUES (
        @InstitutionId,
        @UserId,
        @Location,
        @Happiness,
        @Safety,
        @Reputation,
        @Opportunities,
        @Internet,
        @Food,
        @Social,
        @Facilities,
        @Clubs,
        @Testimony,
        @CreatedAt,
        @Status
    );
END;
