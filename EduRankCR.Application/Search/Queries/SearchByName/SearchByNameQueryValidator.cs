using FluentValidation;

namespace EduRankCR.Application.Search.Queries.SearchByName;

public class SearchByNameQueryValidator : AbstractValidator<SearchByNameQuery>
{
    public SearchByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(255);
    }
}