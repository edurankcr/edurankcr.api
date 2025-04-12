using EduRankCR.Application.Commands.Reviews.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Reviews.Queries;

public record LastReviewsQuery : IRequest<ErrorOr<LastReviewsResult>>;