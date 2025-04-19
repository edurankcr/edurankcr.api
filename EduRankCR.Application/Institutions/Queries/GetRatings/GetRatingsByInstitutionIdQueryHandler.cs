using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetRatings;

internal sealed class GetRatingsByInstitutionIdQueryHandler : IRequestHandler<GetRatingsByInstitutionIdQuery, ErrorOr<List<InstitutionRatingResult>>>
{
    private readonly IInstitutionRatingRepository _repository;

    public GetRatingsByInstitutionIdQueryHandler(IInstitutionRatingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<InstitutionRatingResult>>> Handle(GetRatingsByInstitutionIdQuery request, CancellationToken cancellationToken)
    {
        var ratings = await _repository.GetByInstitutionId(request.InstitutionId);

        return ratings.Select(r => new InstitutionRatingResult(
            new InstitutionRatingInstitutionResult(
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
                (byte)r.Status),
            new InstitutionRatingUserResult(
                r.UserUserId,
                r.UserName,
                r.UserLastName,
                r.UserUserName,
                r.UserAvatarUrl))).ToList();
    }
}