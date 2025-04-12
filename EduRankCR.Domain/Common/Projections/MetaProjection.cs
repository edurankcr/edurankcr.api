namespace EduRankCR.Domain.Common.Projections;

public record MetaProjection(
    int Total,
    int Page,
    int PageSize,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage);