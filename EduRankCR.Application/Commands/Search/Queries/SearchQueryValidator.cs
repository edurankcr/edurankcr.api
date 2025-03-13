using FluentValidation;

namespace EduRankCR.Application.Commands.Search.Queries;

public class SearchQueryValidator : AbstractValidator<SearchQuery>
{
    public SearchQueryValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100)
            .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Invalid characters in Name");

        RuleFor(x => x.Type)
            .NotEmpty()
            .MaximumLength(20)
            .Must(type => new[] { "teacher", "institute", "all" }.Contains(type))
            .WithMessage("Type must be 'teacher', 'institute', or 'all'");

        RuleFor(x => x.InstituteId)
            .Must(id => Guid.TryParse(id, out _))
            .When(x => !string.IsNullOrEmpty(x.InstituteId))
            .WithMessage("Invalid InstituteId format");

        RuleFor(x => x.TypeFilter).InclusiveBetween(1, 3).When(x => x.TypeFilter.HasValue);
        RuleFor(x => x.Province).InclusiveBetween(1, 7).When(x => x.Province.HasValue);
        RuleFor(x => x.District).InclusiveBetween(1, 500).When(x => x.District.HasValue);
    }
}