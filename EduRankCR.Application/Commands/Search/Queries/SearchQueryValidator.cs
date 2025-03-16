using FluentValidation;

namespace EduRankCR.Application.Commands.Search.Queries;

public class SearchQueryValidator : AbstractValidator<SearchQuery>
{
    public SearchQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[\p{L}0-9\s]+$").When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage("Invalid characters in Name. Only letters, numbers, and spaces are allowed.");

        RuleFor(x => x.Type)
            .Must(type => new[] { "teacher", "institute", "all" }.Contains(type))
            .When(x => !string.IsNullOrWhiteSpace(x.Type))
            .WithMessage("Type must be 'teacher', 'institute', or 'all'.");

        RuleFor(x => x.InstituteId)
            .Must(id => Guid.TryParse(id, out _))
            .When(x => !string.IsNullOrWhiteSpace(x.InstituteId))
            .WithMessage("Invalid InstituteId format.");

        RuleFor(x => x.TypeFilter)
            .InclusiveBetween(1, 3)
            .When(x => x.TypeFilter.HasValue)
            .WithMessage("TypeFilter must be between 1 and 3.");

        RuleFor(x => x.Province)
            .InclusiveBetween(1, 7)
            .When(x => x.Province.HasValue)
            .WithMessage("Province must be between 1 and 7.");

        RuleFor(x => x.District)
            .InclusiveBetween(1, 500)
            .When(x => x.District.HasValue)
            .WithMessage("District must be between 1 and 500.");
    }
}