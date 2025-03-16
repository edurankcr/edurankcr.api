using EduRankCR.Application.Commands.Teacher.Commands.Create;
using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.InstituteAggregate.Enums;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateReviewInstituteCommandHandler : IRequestHandler<CreateReviewInstituteCommand, ErrorOr<BoolResult>>
{
    private readonly IInstituteRepository _instituteRepository;

    public CreateReviewInstituteCommandHandler(IInstituteRepository instituteRepository)
    {
        _instituteRepository = instituteRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        CreateReviewInstituteCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = UserId.ConvertFromString(query.UserId);
        InstituteId instituteId = InstituteId.ConvertFromString(query.InstituteId);

        InstituteReview? isReviewed = await _instituteRepository.FindReviewByInstitute(userId, instituteId);

        if (isReviewed?.Id is not null)
        {
            return Errors.Institute.ReviewAlreadyExists;
        }

        Domain.InstituteAggregate.Entities.Institute? institute = await _instituteRepository.Find(instituteId);

        if (institute?.Id is null)
        {
            return Errors.Institute.NotFound;
        }

        if (institute.Status != InstituteStatus.Approved)
        {
            return Errors.Institute.NotApproved;
        }

        InstituteReview review = InstituteReview.Create(
            userId,
            instituteId,
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
            Status.Pending);

        await _instituteRepository.CreateReview(review, instituteId, userId);

        return new BoolResult(true);
    }
}