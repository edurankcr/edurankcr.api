using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Institutions;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Commands.Create;

internal sealed class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, ErrorOr<CreateInstitutionResult>>
{
    private readonly IInstitutionRepository _repository;

    public CreateInstitutionCommandHandler(IInstitutionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<CreateInstitutionResult>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = await _repository.ExistsInReview(request.UserId);

        if (alreadyExists)
        {
            return Errors.Institution.AlreadyInReview;
        }

        var institutionId = Guid.NewGuid();

        var institution = Institution.Create(
            institutionId,
            request.UserId,
            request.Name,
            request.Description,
            request.Province,
            request.Type,
            request.WebsiteUrl,
            null,
            Status.InReview);

        await _repository.Create(institution);

        return new CreateInstitutionResult(institution.InstitutionId);
    }
}