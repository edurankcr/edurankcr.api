using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Commands.Update;

public class UpdateReviewInstituteCommandHandler : IRequestHandler<UpdateReviewInstituteCommand, ErrorOr<BoolResult>>
{
    private readonly IInstituteRepository _instituteRepository;

    public UpdateReviewInstituteCommandHandler(IInstituteRepository instituteRepository)
    {
        _instituteRepository = instituteRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        UpdateReviewInstituteCommand query,
        CancellationToken cancellationToken)
    {
        if (new object?[]
            {
                query.Reputation,
                query.Opportunities,
                query.Happiness,
                query.Location,
                query.Facilities,
                query.Social,
                query.Clubs,
                query.Internet,
                query.Security,
                query.Food,
                query.ExperienceText,
            }.All(value => value is null))
        {
            return Errors.General.NothingToUpdate;
        }

        UserId userId = UserId.ConvertFromString(query.UserId);
        InstituteId instituteId = InstituteId.ConvertFromString(query.InstituteId);

        InstituteReview? recoverReview = await _instituteRepository.FindReviewByInstitute(userId, instituteId);

        if (recoverReview?.Id is null)
        {
            return Errors.Institute.ReviewNotFound;
        }

        await _instituteRepository.UpdateReview(
            recoverReview.Id,
            query.Reputation,
            query.Opportunities,
            query.Happiness,
            query.Location,
            query.Facilities,
            query.Social,
            query.Clubs,
            query.Internet,
            query.Security,
            query.Food,
            query.ExperienceText);

        return new BoolResult(true);
    }
}