using EduRankCR.Application.Account.Common;
using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Queries.GetAccount;

internal sealed class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetAccountQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetProfileById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        return new UserResult(
            user.UserId,
            user.Name,
            user.LastName,
            user.UserName,
            user.Email,
            user.EmailConfirmed,
            user.NewEmail,
            user.Role,
            user.Status,
            user.AvatarUrl,
            user.Biography,
            user.BirthDate,
            user.PasswordChangedAt,
            user.CreatedAt,
            user.UpdatedAt);
    }
}