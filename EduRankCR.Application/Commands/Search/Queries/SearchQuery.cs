using EduRankCR.Application.Commands.Search.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Search.Queries;

public record SearchQuery(
    string Name,
    string? Type, // teacher, institution or all
    string? InstituteId,
    int? TypeFilter, // institution type
    int? Province,
    int? District) : IRequest<ErrorOr<SearchResult>>;