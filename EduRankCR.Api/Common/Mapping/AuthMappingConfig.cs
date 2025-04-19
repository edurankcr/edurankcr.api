using EduRankCR.Application.Auth.Commands.Login;
using EduRankCR.Application.Auth.Commands.Register;
using EduRankCR.Application.Auth.Common;
using EduRankCR.Contracts.Auth;
using Mapster;

namespace EduRankCR.Api.Common.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginCommand>();
        config.NewConfig<AuthResult, AuthResponse>();
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>();
    }
}