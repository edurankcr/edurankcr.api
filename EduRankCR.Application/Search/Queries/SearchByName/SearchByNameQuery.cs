using EduRankCR.Application.Search.Common;
using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Search.Queries.SearchByName;

public sealed record SearchByNameQuery(string Name) : IRequest<ErrorOr<SearchResult>>;