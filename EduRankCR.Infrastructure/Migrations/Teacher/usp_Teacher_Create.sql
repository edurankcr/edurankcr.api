CREATE PROCEDURE usp_Teacher_Create
    @TeacherId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Name NVARCHAR(255),
    @LastName NVARCHAR(255),
    @Biography NVARCHAR(MAX) = NULL,
    @AvatarUrl NVARCHAR(500) = NULL,
    @CreatedAt DATETIME2,
    @UpdatedAt DATETIME2,
    @Status TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Teachers (
        TeacherId,
        UserId,
        Name,
        LastName,
        Biography,
        AvatarUrl,
        CreatedAt,
        UpdatedAt,
        Status
    )
    VALUES (
        @TeacherId,
        @UserId,
        @Name,
        @LastName,
        @Biography,
        @AvatarUrl,
        @CreatedAt,
        @UpdatedAt,
        @Status
    );

    INSERT INTO Teachers_Ratings_Aggregates (
        TeacherId,
        Clarity,
        Knowledge,
        Respect,
        Fairness,
        Punctuality,
        Motivation,
        WouldTakeAgainRatio,
        OverallAverage,
        ReviewCount
    )
    VALUES (
        @TeacherId,
        0, 0, 0, 0, 0, 0, 0, 0, 0
    );
END;
