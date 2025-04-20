using FluentValidation;

namespace EduRankCR.Application.Teachers.Queries.GetById;

public class GetTeacherByIdQueryValidator : AbstractValidator<GetTeacherByIdQuery>
{
    public GetTeacherByIdQueryValidator()
    {
        RuleFor(x => x.TeacherId)
            .NotEmpty().WithMessage("TeacherId is required.");
    }
}