using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Query.Search;

public class SearchInstituteQueryValidator : AbstractValidator<SearchInstituteQuery>
{
    public SearchInstituteQueryValidator()
    {
        RuleFor(x => x.InstituteId)
            .NotEmpty().WithMessage("InstituteId is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid InstituteId format.");
    }
}