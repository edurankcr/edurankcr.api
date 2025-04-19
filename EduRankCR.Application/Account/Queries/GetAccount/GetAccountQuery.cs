using EduRankCR.Application.Account.Common;
using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Queries.GetAccount;

public sealed record GetAccountQuery(Guid UserId) : IRequest<ErrorOr<UserResult>>;