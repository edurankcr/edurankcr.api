CREATE PROCEDURE usp_GetInstitutionById
    @InstitutionId UNIQUEIDENTIFIER
AS
BEGIN
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
