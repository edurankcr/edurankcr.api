using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetRatings;

internal sealed class GetRatingsByInstitutionIdQueryHandler : IRequestHandler<GetRatingsByInstitutionIdQuery, ErrorOr<List<InstitutionRatingResult>>>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IInstitutionRatingRepository _repository;

    public GetRatingsByInstitutionIdQueryHandler(
        IInstitutionRepository institutionRepository,
        IInstitutionRatingRepository repository)
    {
        _institutionRepository = institutionRepository;
        _repository = repository;
    }

    public async Task<ErrorOr<List<InstitutionRatingResult>>> Handle(GetRatingsByInstitutionIdQuery request, CancellationToken cancellationToken)
    {
        var institution = await _institutionRepository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        var ratings = await _repository.GetByInstitutionId(request.InstitutionId);

        if (ratings is null)
        {
            return new List<InstitutionRatingResult>();
        }

        var mapped = ratings.Select(r => new InstitutionRatingResult(
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
            new UserMinimalResult(
                r.UserUserId,
                r.UserName,
                r.UserLastName,
                r.UserUserName,
                r.UserAvatarUrl))).ToList();

        return mapped;
    }
}