using EduRankCR.Application.Commands.Profile.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Queries.Profile;

public record ProfileQuery(string UserId) : IRequest<ErrorOr<ProfileResult>>;