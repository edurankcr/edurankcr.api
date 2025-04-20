using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetLatestRatings;

public sealed class GetLatestInstitutionRatingsQueryHandler
    : IRequestHandler<GetLatestInstitutionRatingsQuery, ErrorOr<GetLatestInstitutionRatingsResult>>
{
    private readonly IInstitutionRatingRepository _repository;

    public GetLatestInstitutionRatingsQueryHandler(IInstitutionRatingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<GetLatestInstitutionRatingsResult>> Handle(
        GetLatestInstitutionRatingsQuery request,
        CancellationToken cancellationToken)
    {
        var ratings = await _repository.GetLatestRatings();

        var mapped = ratings.Select(r => new LatestInstitutionRating(
            r.InstitutionRatingId,
            r.InstitutionId,
            r.UserId,
            r.Location,
            r.Happiness,
            r.Safety,
            r.Reputation,
            r.Opportunities,
            r.Internet,
            r.Food,
            r.Social,
            r.Facilities,
            r.Clubs,
            r.Testimony,
            r.CreatedAt,
            r.UpdatedAt,
            (byte)r.Status,
            new LatestRatingUser(
                r.UserUserId,
                r.UserName,
                r.UserLastName,
                r.UserUserName,
                r.UserAvatarUrl))).ToList();

        return new GetLatestInstitutionRatingsResult(mapped);
    }
}