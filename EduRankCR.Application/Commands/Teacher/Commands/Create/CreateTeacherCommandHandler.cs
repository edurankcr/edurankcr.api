using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Errors;
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

        Domain.InstituteAggregate.Entities.Institute? institute = await _instituteRepository.Find(InstituteId.ConvertFromString(query.InstituteId));

        if (institute?.Id is null)
        {
            return Errors.Institute.NotFound;
        }

        Domain.TeacherAggregate.Entities.Teacher teacher = Domain.TeacherAggregate.Entities.Teacher.Create(
            user.Id,
            institute.Id,
            query.Name,
            query.LastName,
            TeacherStatus.Pending);

        await _teacherRepository.Create(teacher);

        return new BoolResult(true);
    }
}