using EduRankCR.Application.Activity.Common;
using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Activity.Queries.GetLastActivity;

public sealed class GetLastActivityQueryHandler : IRequestHandler<GetLastActivityQuery, ErrorOr<LastActivityResult>>
{
    private readonly IActivityRepository _repository;

    public GetLastActivityQueryHandler(IActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<LastActivityResult>> Handle(GetLastActivityQuery request, CancellationToken cancellationToken)
    {
        var institutions = await _repository.GetLatestInstitutionReviews();
        var teachers = await _repository.GetLatestTeacherReviews();

        var institutionReviews = institutions.Select(r => new InstitutionActivityItem(
            r.InstitutionRatingId,
            r.InstitutionId,
            r.Location,
            r.Happiness,
            r.Safety,
            r.Reputation,
            r.Opportunities,
            r.Internet,
            r.Food,
            r.Social,
            r.Facilities,
            r.Clubs,
            r.Testimony,
            r.CreatedAt,
            r.UpdatedAt,
            new UserMinimalResult(
                r.UserUserId,
                r.UserName,
                r.UserLastName,
                r.UserUserName,
                r.UserAvatarUrl))).ToList();

        var teacherReviews = teachers.Select(r => new TeacherActivityItem(
            r.TeacherRatingId,
            r.TeacherId,
            r.Clarity,
            r.Knowledge,
            r.Respect,
            r.Fairness,
            r.Punctuality,
            r.Motivation,
            r.WouldTakeAgain,
            r.Testimony,
            r.CreatedAt,
            r.UpdatedAt,
            new UserMinimalResult(
                r.UserUserId,
                r.UserName,
                r.UserLastName,
                r.UserUserName,
                r.UserAvatarUrl))).ToList();

        return new LastActivityResult(
            institutionReviews,
            teacherReviews);
    }
}