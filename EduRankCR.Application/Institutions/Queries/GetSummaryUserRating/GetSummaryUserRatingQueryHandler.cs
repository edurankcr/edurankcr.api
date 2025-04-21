using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetSummaryUserRating;

public sealed class GetSummaryUserRatingQueryHandler : IRequestHandler<GetSummaryUserRatingQuery, ErrorOr<InstitutionUserRatingResult>>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IInstitutionRatingRepository _ratingRepository;

    public GetSummaryUserRatingQueryHandler(
        IInstitutionRepository institutionRepository,
        IInstitutionRatingRepository ratingRepository)
    {
        _institutionRepository = institutionRepository;
        _ratingRepository = ratingRepository;
    }

    public async Task<ErrorOr<InstitutionUserRatingResult>> Handle(GetSummaryUserRatingQuery request, CancellationToken cancellationToken)
    {
        var institution = await _institutionRepository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        var rating = await _ratingRepository.GetByInstitutionAndUser(request.InstitutionId, request.UserId);

        InstitutionRatingInstitutionResult? mappedRating = null;

        if (rating is not null)
        {
            mappedRating = new InstitutionRatingInstitutionResult(
                rating.InstitutionRatingId,
                rating.InstitutionId,
                rating.UserId,
                rating.Location,
                rating.Happiness,
                rating.Safety,
                rating.Reputation,
                rating.Opportunities,
                rating.Internet,
                rating.Food,
                rating.Social,
                rating.Facilities,
                rating.Clubs,
                rating.Testimony,
                rating.CreatedAt,
                rating.UpdatedAt,
                (byte)rating.Status);
        }

        var mappedInstitution = new InstitutionResult(
            institution.InstitutionId,
            institution.Name,
            institution.Description,
            institution.Province,
            (byte)institution.Type,
            institution.WebsiteUrl,
            institution.AiReviewSummary,
            institution.CreatedAt,
            institution.UpdatedAt,
            (byte)institution.Status);

        return new InstitutionUserRatingResult(
            HasRating: rating is not null,
            Rating: mappedRating,
            Institution: mappedInstitution);
    }
}