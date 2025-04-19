CREATE PROCEDURE usp_Institution_Create
    @InstitutionId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(150),
    @Description NVARCHAR(MAX) = NULL,
    @Province TINYINT,
    @Type TINYINT,
    @WebsiteUrl NVARCHAR(255) = NULL,
    @AiReviewSummary NVARCHAR(MAX) = NULL,
    @Status TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Institutions (
        InstitutionId,
        UserId,
        Name,
        Description,
        Province,
        Type,
        WebsiteUrl,
        AiReviewSummary,
        CreatedAt,
        UpdatedAt,
        Status
    )
    VALUES (
        @InstitutionId,
        @UserId,
        @Name,
        @Description,
        @Province,
        @Type,
        @WebsiteUrl,
        @AiReviewSummary,
        GETDATE(),
        GETDATE(),
        @Status
    );

    INSERT INTO Institutions_Ratings_Aggregate (
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
        @InstitutionId,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    );
END;
