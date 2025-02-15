using FluentValidation;
using EduRankCR.Application.DTOs;

public class RequestMainUserIdDtoValidator : AbstractValidator<RequestMainUserIdDto>
{
    public RequestMainUserIdDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID_CANNOT_BE_EMPTY");
    }
}