using FluentValidation;

namespace EduRankCR.Application.Institutions.Queries.GetInstitutionById;

public class GetInstitutionByIdQueryValidator : AbstractValidator<GetInstitutionByIdQuery>
{
    public GetInstitutionByIdQueryValidator()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty().WithMessage("InstitutionId is required.");
    }
}