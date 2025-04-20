using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Institutions;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Commands.CreateRating;

internal sealed class CreateInstitutionRatingCommandHandler
    : IRequestHandler<CreateInstitutionRatingCommand, ErrorOr<Unit>>
{
    private readonly IInstitutionRatingRepository _institutionRatingRepository;
    private readonly IInstitutionRepository _institutionRepository;

    public CreateInstitutionRatingCommandHandler(
        IInstitutionRatingRepository institutionRatingRepository,
        IInstitutionRepository institutionRepository)
    {
        _institutionRatingRepository = institutionRatingRepository;
        _institutionRepository = institutionRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(
        CreateInstitutionRatingCommand request,
        CancellationToken cancellationToken)
    {
        var institution = await _institutionRepository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        var hasUserAlreadyRated = await _institutionRatingRepository.HasUserAlreadyRated(request.InstitutionId, request.UserId);

        if (hasUserAlreadyRated)
        {
            return Errors.InstitutionRating.AlreadyExists;
        }

        var rating = InstitutionRating.Create(
            institutionRatingId: Guid.NewGuid(),
            institutionId: request.InstitutionId,
            userId: request.UserId,
            location: request.Location,
            happiness: request.Happiness,
            safety: request.Safety,
            reputation: request.Reputation,
            opportunities: request.Opportunities,
            internet: request.Internet,
            food: request.Food,
            social: request.Social,
            facilities: request.Facilities,
            clubs: request.Clubs,
            testimony: request.Testimony,
            status: Status.InReview);

        await _institutionRatingRepository.CreateRating(rating);

        return Unit.Value;
    }
}