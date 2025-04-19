CREATE PROCEDURE usp_Institution_GetById
    @InstitutionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        InstitutionId,
        Name,
        Description,
        Province,
        Type,
        WebsiteUrl,
        AiReviewSummary,
        CreatedAt,
        UpdatedAt,
        Status
    FROM Institutions
    WHERE InstitutionId = @InstitutionId;
END
