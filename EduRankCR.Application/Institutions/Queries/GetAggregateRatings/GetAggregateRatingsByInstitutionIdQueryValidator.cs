using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetAggregateRatings;

public class GetAggregateRatingsByInstitutionIdQueryValidator : AbstractValidator<GetAggregateRatingsByInstitutionIdQuery>
{
    public GetAggregateRatingsByInstitutionIdQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");
    }
}