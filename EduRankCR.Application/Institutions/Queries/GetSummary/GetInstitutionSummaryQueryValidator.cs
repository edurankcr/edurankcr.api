using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetSummary;

public class GetInstitutionSummaryQueryValidator : AbstractValidator<GetInstitutionSummaryQuery>
{
    public GetInstitutionSummaryQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");
    }
}