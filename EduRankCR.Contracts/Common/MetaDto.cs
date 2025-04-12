namespace EduRankCR.Contracts.Common;

public record MetaDto(
    int Total,
    int Page,
    int PageSize,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage);