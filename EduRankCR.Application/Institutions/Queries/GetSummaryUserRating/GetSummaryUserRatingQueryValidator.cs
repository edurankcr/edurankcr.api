using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetSummaryUserRating;

public class GetSummaryUserRatingQueryValidator : AbstractValidator<GetSummaryUserRatingQuery>
{
    public GetSummaryUserRatingQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}