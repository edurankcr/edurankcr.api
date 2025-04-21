using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Commands.UpdateRating;

internal sealed class UpdateInstitutionRatingCommandHandler
    : IRequestHandler<UpdateInstitutionRatingCommand, ErrorOr<Unit>>
{
    private readonly IInstitutionRatingRepository _repository;

    public UpdateInstitutionRatingCommandHandler(IInstitutionRatingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateInstitutionRatingCommand request, CancellationToken cancellationToken)
    {
        var ratingId = await _repository.GetByInstitutionAndUser(request.InstitutionId, request.UserId);

        if (ratingId is null)
        {
            return Errors.Institution.NotFound;
        }

        await _repository.Update(
            ratingId.InstitutionRatingId,
            request.UserId,
            request.Location,
            request.Happiness,
            request.Safety,
            request.Reputation,
            request.Opportunities,
            request.Internet,
            request.Food,
            request.Social,
            request.Facilities,
            request.Clubs,
            request.Testimony);

        return Unit.Value;
    }
}