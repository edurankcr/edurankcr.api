using EduRankCR.Application.Commands.Reviews.Common;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Projections;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Reviews.Queries;

public class LastReviewsQueryHandler : IRequestHandler<LastReviewsQuery, ErrorOr<LastReviewsResult>>
{
    private readonly IReviewsRepository _reviewsRepository;

    public LastReviewsQueryHandler(IReviewsRepository searchRepository)
    {
        _reviewsRepository = searchRepository;
    }

    public async Task<ErrorOr<LastReviewsResult>> Handle(LastReviewsQuery query, CancellationToken cancellationToken)
    {
        var (teachersReviews, institutesReviews) = await _reviewsRepository.GetLastReviews();

        return new LastReviewsResult(
            new MetaProjection(teachersReviews.Count + institutesReviews.Count, 1, 1, 1, false, false),
            new LastReviewsContent(teachersReviews, institutesReviews));
    }
}