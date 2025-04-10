using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Enums;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public class CreateInstituteCommandHandler : IRequestHandler<CreateInstituteCommand, ErrorOr<BoolResult>>
{
    private readonly IInstituteRepository _instituteRepository;
    private readonly IUserRepository _userRepository;

    public CreateInstituteCommandHandler(IInstituteRepository instituteRepository, IUserRepository userRepository)
    {
        _instituteRepository = instituteRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        CreateInstituteCommand query,
        CancellationToken cancellationToken)
    {
        User? user = await _userRepository.FindById(UserId.ConvertFromString(query.UserId));

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        Domain.InstituteAggregate.Entities.Institute institute = Domain.InstituteAggregate.Entities.Institute.Create(
            user.Id,
            query.Name,
            (InstituteType)query.Type,
            (Province)query.Province,
            query.Url,
            Status.Pending);

        await _instituteRepository.Create(institute);

        return new BoolResult(true);
    }
}