using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Enums;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Teacher.Commands.Create;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ErrorOr<BoolResult>>
{
    private readonly IInstituteRepository _instituteRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITeacherRepository _teacherRepository;

    public CreateTeacherCommandHandler(
        IInstituteRepository instituteRepository,
        IUserRepository userRepository,
        ITeacherRepository teacherRepository)
    {
        _instituteRepository = instituteRepository;
        _userRepository = userRepository;
        _teacherRepository = teacherRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        CreateTeacherCommand query,
        CancellationToken cancellationToken)
    {
        User? user = await _userRepository.FindById(UserId.ConvertFromString(query.UserId));

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        Domain.TeacherAggregate.Entities.Teacher teacher = Domain.TeacherAggregate.Entities.Teacher.Create(
            user.Id,
            query.Name,
            query.LastName,
            Status.Pending);

        await _teacherRepository.Create(teacher);

        return new BoolResult(true);
    }
}