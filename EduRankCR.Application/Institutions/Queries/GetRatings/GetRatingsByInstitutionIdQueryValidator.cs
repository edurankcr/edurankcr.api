using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetRatings;

public class GetRatingsByInstitutionIdQueryValidator : AbstractValidator<GetRatingsByInstitutionIdQuery>
{
    public GetRatingsByInstitutionIdQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");
    }
}