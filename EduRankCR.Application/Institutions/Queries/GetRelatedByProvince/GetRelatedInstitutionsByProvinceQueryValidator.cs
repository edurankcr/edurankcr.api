using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetRelatedByProvince;

public class GetRelatedInstitutionsByProvinceQueryValidator
    : AbstractValidator<GetRelatedInstitutionsByProvinceQuery>
{
    public GetRelatedInstitutionsByProvinceQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");
    }
}