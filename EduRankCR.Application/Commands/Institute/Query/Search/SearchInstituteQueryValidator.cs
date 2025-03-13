using FluentValidation;

namespace EduRankCR.Application.Commands.Institute.Query.Search;

public class SearchInstituteQueryValidator : AbstractValidator<SearchInstituteQuery>
{
    public SearchInstituteQueryValidator()
    {
        RuleFor(x => x.InstituteId)
            .Must(id => Guid.TryParse(id, out _))
            .When(x => !string.IsNullOrEmpty(x.InstituteId))
            .WithMessage("Invalid InstituteId format");
    }
}