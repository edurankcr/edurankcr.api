using EduRankCR.Application.Commands.Institute.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Query.Search;

public record SearchInstituteQuery(string InstituteId) : IRequest<ErrorOr<SearchInstituteResult>>;