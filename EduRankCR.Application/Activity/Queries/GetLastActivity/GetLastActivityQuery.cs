using EduRankCR.Application.Activity.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Activity.Queries.GetLastActivity;

public sealed record GetLastActivityQuery : IRequest<ErrorOr<LastActivityResult>>;