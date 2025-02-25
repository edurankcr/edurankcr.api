using EduRankCR.Application.Profile.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Profile.Queries.Profile;

public record ProfileQuery(string UserId) : IRequest<ErrorOr<ProfileResult>>;